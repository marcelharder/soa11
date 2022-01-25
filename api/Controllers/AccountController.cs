using System;
using System.Threading.Tasks;
using api.DTOs;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {

        private readonly ITokenService _ts;
        private IMapper _mapper;
        private readonly UserManager<AppUser> _manager;
        private readonly SignInManager<AppUser> _signIn;
        private readonly IConfiguration _config;
        public AccountController(
            ITokenService ts,
            IMapper mapper,
            IConfiguration config,
            UserManager<AppUser> manager,
            SignInManager<AppUser> signIn)
        {
            _config = config;

            _manager = manager;
            _signIn = signIn;
            _mapper = mapper;
            _ts = ts;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserForRegisterDto registerDto)
        {

            var user = await _manager.Users.SingleOrDefaultAsync(x => x.UserName == registerDto.UserName.ToLower());
            if (user != null) { return BadRequest("User already exists ..."); }

            user = new AppUser { 
                
                UserName = registerDto.UserName.ToLower(),
                Country = "NL",
                Created = DateTime.Now,
                LastActive = DateTime.Now,
                active = true,
                ltk = false
                             
                
                 };

            var result = await _manager.CreateAsync(user, registerDto.password);
            if (!result.Succeeded) { return BadRequest(result.Errors); }

            var roleResult = await _manager.AddToRoleAsync(user, "Surgeon");
            if(!roleResult.Succeeded){return BadRequest(roleResult.Errors); }

            return new UserDto
            {
                Username = user.UserName,
                Token = await _ts.CreateToken(user)
            };

           
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserForLoginDto ufl)
        {
           var user = await _manager.Users.SingleOrDefaultAsync(x => x.UserName == ufl.UserName.ToLower());
           if (user == null) return Unauthorized();

           var result = await _signIn.CheckPasswordSignInAsync(user, ufl.password, false);
           if(!result.Succeeded) return Unauthorized();

           return new UserDto
            {
                Username = user.UserName,
                Token = await _ts.CreateToken(user)
            };
        }

        [HttpPut("changePassword/{newpassword}")]
        public async Task<ActionResult<UserDto>> CP(UserForLoginDto ufl, string newpassword)
        {
            var user = new AppUser { UserName = ufl.UserName.ToLower() }; 
            await _manager.ChangePasswordAsync(user, ufl.password, newpassword);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _ts.CreateToken(user)
            };
        }



    }

}
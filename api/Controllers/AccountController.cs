using System;
using System.Threading.Tasks;
using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

            var roleResult = await _manager.AddToRoleAsync(user, "Surgery");
            if(!roleResult.Succeeded){return BadRequest(roleResult.Errors); }

            return new UserDto
            {
                Username = user.UserName,
                Token = await _ts.CreateToken(user),
                UserId = user.Id
            };

           
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserForLoginDto ufl)
        {
           var user = await _manager.Users.SingleOrDefaultAsync(x => x.UserName == ufl.UserName.ToLower());
           if (user == null) return Unauthorized();

           // check if this is a premium user
           var now = DateTime.UtcNow;

           if(now.Ticks < user.PaidTill.Ticks){
            var roleResult = await _manager.AddToRoleAsync(user, "Premium");
            if(!roleResult.Succeeded){return BadRequest(roleResult.Errors); }
           }

           var result = await _signIn.CheckPasswordSignInAsync(user, ufl.password, false);
           if(!result.Succeeded) return Unauthorized();
          

           return new UserDto
            {
                Username = user.UserName,
                Token = await _ts.CreateToken(user),
                UserId = user.Id
            };
        }

        [HttpPut("changePassword/{newpassword}")]
        public async Task<ActionResult<UserDto>> CP(UserForLoginDto ufl, string newpassword)
        {
            // find existing user by username
            var user = await _manager.Users.SingleOrDefaultAsync(x => x.UserName == ufl.UserName.ToLower());
         
            await _manager.ChangePasswordAsync(user, ufl.password, newpassword);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _ts.CreateToken(user),
                UserId = user.Id
            };
        }



    }

}
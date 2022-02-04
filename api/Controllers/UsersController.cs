using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserForReturnDto>>> GetUsersAsync()
        {
            var result = new List<UserForReturnDto>();
            var users = await _userRepository.GetUsersAsync();
            foreach(AppUser au in users){ result.Add(_mapper.Map<AppUser, UserForReturnDto>(au)); }
            return Ok(result);
        }

       [HttpGet("{id}")]
        public async Task<ActionResult<UserForReturnDto>> GetUserById(int id)
        {   var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<AppUser, UserForReturnDto>(user);
        }


    }
}
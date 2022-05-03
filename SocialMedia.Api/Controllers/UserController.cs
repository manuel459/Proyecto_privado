using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core.DTOS;
using SocialMedia.Core.Entities;
using AutoMapper;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserController(IUserRepository userRepository,IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var lst = await _userRepository.Get();
            var UserDtos = _mapper.Map<IEnumerable<UserDtos>>(lst);
            return Ok(UserDtos);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetForId(int id) 
        {
            var lst = await _userRepository.GetForId(id);
            var UserDtos = _mapper.Map<UserDtos>(lst);
            return Ok(UserDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDtos userDtos) 
        {
            var UserDtos = _mapper.Map<User>(userDtos);
            await _userRepository.Post(UserDtos);
            return Ok(userDtos);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user) 
        {
            await _userRepository.Update(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id) 
        {
            await _userRepository.Delete(id);
            return Ok(id);
        }

    }
}

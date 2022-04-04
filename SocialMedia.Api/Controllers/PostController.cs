using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        public readonly IPostRepository _ipostRepository;

        public PostController(IPostRepository ipostRepository) {
            _ipostRepository = ipostRepository;
        }

        [HttpGet]

        public async Task<IActionResult> Get() {
            var lst =  await _ipostRepository.Get();
            return Ok(lst);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPost(int id) {
            var post = await _ipostRepository.GetPost(id);
            return Ok(post);
        }

        [HttpPost]

        public async Task<IActionResult> InsertPost(Post post) 
        {
            await _ipostRepository.InsertPost(post);
            return Ok(post);
        }
    }
}

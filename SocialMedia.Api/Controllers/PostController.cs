using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core.DTOS;
using AutoMapper;
using SocialMedia.Api.Response;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        public readonly IPostService _postService;
        public readonly IMapper _mapper;
        public readonly SocialMediaContext _context;
        public PostController(IPostService postService,IMapper mapper,SocialMediaContext context) {
            _postService = postService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get() {
            //tra el metodo get para listar
            var lst =  await _postService.Get();
            //Mapea los dtos
            var PostDtos = _mapper.Map<IEnumerable<PostDtos>>(lst);
            var response = new ApiResponse<IEnumerable<PostDtos>>(PostDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPost(int id) {
            var post = await _postService.GetPost(id);
            var postDtos = _mapper.Map<PostDtos>(post);
            var response = new ApiResponse<PostDtos>(postDtos);
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDtos postDto) 
        {
            var post = _mapper.Map<Post>(postDto);
            await _postService.InsertPost(post);
            postDto = _mapper.Map<PostDtos>(post);
            var response = new ApiResponse<PostDtos>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id,PostDtos postDtos) 
        {
            var post = _mapper.Map<Post>(postDtos);
            post.PostId = id;

            var result = await _postService.Update(post);
            var response = new ApiResponse<bool>(result);
            return Ok(post);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

        [HttpPost("Buscar")]
        public IActionResult Buscar(PostDtos request) {
            var lst = (from p in _context.Posts
                       join u in _context.Users
                       on p.UserId equals u.UserId
                       where p.PostId == request.PostId && p.UserId == request.UserId
                       select new { u.FirstName , u.LastName, p.Description });

            return Ok(lst);
        }

       

    
    }
}

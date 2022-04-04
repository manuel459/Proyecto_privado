using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        public readonly IComentario _comentario;

        public ComentarioController(IComentario comentario) {
            _comentario = comentario;
        }

        [HttpGet]
        public async Task<IActionResult> GetComentario() 
        {
            var lst = await _comentario.GetComentarios();
            return Ok(lst);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetComment(int id) 
        {
            var post = await _comentario.GetComment(id);
            return Ok(post);
        }

        [HttpPost]

        public async Task<IActionResult> InsertCommet(Comment comment) 
        {
            await _comentario.InsertComment(comment);

            return Ok(comment);
        }

    }
}

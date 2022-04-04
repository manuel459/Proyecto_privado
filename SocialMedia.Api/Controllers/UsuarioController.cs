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
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios() 
        {

            var lst = await _usuarioRepository.GetUsuarios();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id) 
        {
            var post = await _usuarioRepository.GetUser(id);
            return Ok(post);
        }

        [HttpPost]

        public async Task<IActionResult> InsertUser(User user) 
        {
            await _usuarioRepository.InsertUser(user);
            return Ok(user);
        }
    }
}

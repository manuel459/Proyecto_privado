using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly SocialMediaContext _context;

        public UsuarioRepository(SocialMediaContext context) {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsuarios()
        {
            var lst = await _context.Users.ToListAsync();

            return lst;
        }

        public async Task<User> GetUser(int id)
        {
            var post = await _context.Users.FirstOrDefaultAsync(x=> x.UserId == id);
            return post;
        }

        public async Task InsertUser(User user)
        {
             _context.Users.Add(user);
             await _context.SaveChangesAsync();
        }
    }
}

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
    public class ComentarioRepossitory : IComentario
    {
        public readonly SocialMediaContext _context;

        public ComentarioRepossitory(SocialMediaContext context) {
            _context = context;
        }


        public async Task<IEnumerable<Comment>> GetComentarios()
        {
            var lst = await _context.Comments.ToListAsync();

            return lst;
        }
        
        public async Task<Comment> GetComment(int id)
        {
            var post = await _context.Comments.FirstOrDefaultAsync(x=>x.CommentId == id);
            return post;

        }

        public async Task InsertComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

    }
}

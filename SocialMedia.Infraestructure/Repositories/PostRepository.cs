using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.DTOS;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Post>> Get()
        {
            var lst = await _context.Posts.ToListAsync();
            var lstDto = lst.Select(x=> new PostDtos 
            {
                PostId = x.PostId,
                Date = x.Date,
                Description = x.Description,
                Image = x.Image,
                UserId = x.UserId
            });
            return lst;
        }

        public async Task<Post> GetPost(int id) {
            var lst = await _context.Posts.FirstOrDefaultAsync(x=> x.UserId == id);

            var postDtos = new PostDtos
            {
                PostId = lst.PostId,
                Date = lst.Date,
                Description = lst.Description,
                Image = lst.Image,
                UserId = lst.UserId
            };
            return lst;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
             await _context.SaveChangesAsync();
        }
    }
}

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
            return lst;
        }

        public async Task<Post> GetPost(int id) {
            var lst = await _context.Posts.FirstOrDefaultAsync(x=> x.PostId == id);
            return lst;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
             await _context.SaveChangesAsync();
        }


        public async Task<bool> Update(Post post)   
        {
            var current = await GetPost(post.PostId);
            current.Date = post.Date;
            current.Description = post.Description;
            current.Image = post.Image;

           var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id) 
        {
            var current = await GetPost(id);
            _context.Posts.Remove(current);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<List<Post>> GetPostId(int id)
        {
            var lst = await (from o in _context.Posts
                       where o.UserId==id
                       select o).ToListAsync();
            return lst;
        }

       
    }
}

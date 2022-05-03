using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : IUserRepository
    {
        public readonly SocialMediaContext _context;
        

        public UserRepository(SocialMediaContext context) 
        {
            _context = context;
        }


        public async Task<IEnumerable<User>> Get()
        {
            var lst = await _context.Users.ToListAsync();
           return lst;
        }

        public Task<User> GetForId(int id)
        {
            var lst = _context.Users.FirstOrDefaultAsync(x=>x.UserId == id);
            return lst;
        }

        public async Task Post(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(User user)
        {
                var current = await GetForId(user.UserId);

                current.FirstName = user.FirstName;
                current.LastName = user.LastName;
                current.Email = user.Email;
                current.DateBirth = user.DateBirth;
                current.Telephone = user.Telephone;
                current.IsActive = user.IsActive;
                var rows = await _context.SaveChangesAsync();
                return rows > 0;
            
        }

        public async Task<bool> Delete(int id)
        {
          var current = await GetForId(id);
            _context.Users.Remove(current);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
    }
}

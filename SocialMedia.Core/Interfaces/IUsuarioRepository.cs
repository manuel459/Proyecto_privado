using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<User>> GetUsuarios();
        Task<User> GetUser(int id);
        Task InsertUser(User user);
    }
}

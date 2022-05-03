using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetForId(int id);
        Task Post(User user);
        Task<bool> Update(User user);

        Task<bool> Delete(int id);
    }
}

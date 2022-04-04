using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> Get(); 
        Task<Post> GetPost(int id);
        Task InsertPost(Post post); 

       
    }
}

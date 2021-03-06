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
        Task<bool> Update(Post post);
        Task<bool> Delete(int id);

        //Publicacion por userid
        Task<List<Post>> GetPostId(int id);
    }
}

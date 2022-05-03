using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostServices : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostServices(IPostRepository postRepository,IUserRepository userRepository) 
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Post>> Get()
        {
           return await _postRepository.Get();
        }
        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }
        public async Task InsertPost(Post post)
        {
            var user = await _userRepository.GetForId(post.UserId);
            var users = await _postRepository.GetPostId(post.UserId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (post.Description.Equals("Sexo"))
            {
                throw new Exception("inappropriate content");
            }
            
            if (users.Count()<10)
            {
                throw new Exception("No puedes insertar mas de dos publicaciones por semana");
            }
            await _postRepository.InsertPost(post);
        }
        public async Task<bool> Update(Post post)
        {
            return await _postRepository.Update(post);
        }
        public async Task<bool> Delete(int id)
        {
            return await _postRepository.Delete(id);
        }
    }
}

using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IComentario
    {
        Task<IEnumerable<Comment>> GetComentarios();
        Task<Comment> GetComment(int id);
        Task InsertComment(Comment comment);
    }
}

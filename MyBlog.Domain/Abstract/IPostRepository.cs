using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Domain.Entity;

namespace MyBlog.Domain.Abstract
{
     public interface IPostRepository : IDisposable
    {
       IQueryable<Post> GetPosts { get; }

        Post GetPostById(int PostId);

        void CreatePost(Post post);
        void DeletePost(int PostId);
        void UpdatePost(Post post);
        void save();
    }
}

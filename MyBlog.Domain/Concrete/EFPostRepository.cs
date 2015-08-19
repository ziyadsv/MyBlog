using MyBlog.Domain.Abstract;
using MyBlog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Concrete
{
    public class EFPostRepository :IPostRepository ,IDisposable
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Post> GetPosts { get { return context.Posts; } }
       // public IEnumerable<Post> PostByCategories { get {return context.Categories.Select(x=>x.CategoryId); } }

        public Post GetPostById(int id)
        {
            return context.Posts.Find(id);
        }

        public void CreatePost(Post post)
        {
             context.Posts.Add(post);
        }

        public void DeletePost(int id)
        {
           Post post = context.Posts.Find(id);
            context.Posts.Remove(post);
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State = EntityState.Modified;
        }

        public void save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

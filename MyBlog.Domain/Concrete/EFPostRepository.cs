using MyBlog.Domain.Abstract;
using MyBlog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Concrete
{
    public class EFPostRepository :IPostRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Post> Posts { get { return context.Posts; } }
       // public IEnumerable<Post> PostByCategories { get {return context.Categories.Select(x=>x.CategoryId); } }

    }
}

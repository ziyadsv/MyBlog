using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Domain.Entity;
using MyBlog.Domain.Abstract;

namespace MyBlog.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
       // private EFCategoryRepository context = new EFCategoryRepository();
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Category> Categories { get { return context.Categories ; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Domain.Entity;

namespace MyBlog.Domain.Abstract
{
     public interface IPostRepository
    {
       IEnumerable<Post> Posts { get; }
    }
}

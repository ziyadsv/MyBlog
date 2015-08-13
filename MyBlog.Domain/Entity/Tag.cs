using System.Collections.Generic;

namespace MyBlog.Domain.Entity
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
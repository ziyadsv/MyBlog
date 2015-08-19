﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entity
{
    public class Post
    {
        public Post() { this.PostedOn = DateTime.Now; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string  Meta { get; set; }
        public string UrlSlug { get; set; }
        public string  PublishedBy { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; private set; }
        public DateTime? Modified { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tag { get; set; }
    
    }
}

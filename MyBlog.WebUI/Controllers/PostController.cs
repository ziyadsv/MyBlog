using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Domain.Abstract;

namespace MyBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository repository;

        public PostController( IPostRepository postRepository)
        {
            this.repository = postRepository;
        }
        // GET: Post
        public ActionResult List()
        {
            return View(repository.Posts);
        }

        public ActionResult PostByCategories()
        {
            return View();
        }
    }
}
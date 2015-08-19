using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Domain.Abstract;
using MyBlog.Domain.Entity;
using System.Data;
using System.Net;
using PagedList;
using System.Data.Entity;
using MyBlog.Domain.Concrete;

namespace MyBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository repository;
        private EFDbContext db = new EFDbContext();
        public PostController( IPostRepository postRepository)
        {
            this.repository = postRepository;
        }


        //GET: Post
        public ActionResult List(int page =1)
        {
            var post = repository.GetPosts;

             //int Pagesize = 4;
             //int pagenumber = (page ?? 1);
             //return View(post.Where(p => p.Published).OrderByDescending(s => s.PostedOn).Skip(pagenumber * Pagesize).ToPagedList(pagenumber, Pagesize));
            //return View(post.OrderByDescending(s => s.PostedOn).Skip(pagenumber * Pagesize).ToPagedList(pagenumber, Pagesize));
             return View(post.OrderByDescending(s=>s.PostedOn).ToPagedList(page, 9));
        }

        //public ActionResult List()
        //{

        //    return View(repository.GetPosts);
        //}

        public ActionResult Detail( int id)
        {
           Post post = repository.GetPostById(id);
            return View(post);
        }

        // GET: /Student/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,ShortDescription,Description,Meta,UrlSlug,PublishedBy,Published,Modified,CategoryId")] Post post)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    repository.CreatePost(post);
                    repository.save();
                    return RedirectToAction("List");

                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        public ActionResult Edit(int id)
        {
           
            Post post = repository.GetPostById(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post); 
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "PostId,Title,ShortDescription,Description,Meta,UrlSlug,PublishedBy,Published,Modified")] Post post)
        {
            if (ModelState.IsValid)
            {
                repository.UpdatePost(post);
                repository.save();
                return RedirectToAction("List");
            }
            return View(post);
        }

        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Post post = repository.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Post post = repository.GetPostById(id);
                repository.DeletePost(id);
                repository.save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("List");

        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }


        //Admin
        public ActionResult AdminIndex()
        {
            return View(repository.GetPosts.ToList());
        }
    }
}
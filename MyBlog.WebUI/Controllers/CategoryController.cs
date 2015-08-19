using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Domain.Abstract;

namespace MyBlog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository ;
        public CategoryController (ICategoryRepository categoryRepository)
        {
            this.repository = categoryRepository;
        }

        // GET: Category
        public ActionResult CategoryList()
        {
            return View(repository.GetCategories);
        }

      
    }
}
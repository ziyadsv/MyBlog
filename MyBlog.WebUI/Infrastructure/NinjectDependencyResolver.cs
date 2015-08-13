using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Ninject;
using Moq;
using MyBlog.Domain.Abstract;
using MyBlog.Domain.Entity;


namespace MyBlog.WebUI.Infrastructure
{
    public  class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {


        private IKernel kernel;


        public NinjectDependencyResolver(IKernel kernelParam)
        {


            kernel = kernelParam;


            AddBindings();


        }


        public object GetService(Type serviceType)
        {


            return kernel.TryGet(serviceType);


        }


        public IEnumerable<object> GetServices(Type serviceType)
        {


            return kernel.GetAll(serviceType);


        }


        private void AddBindings()
        {
            //Mock<ICategoryRepository> mockCategory = new Mock<ICategoryRepository>();
            //mockCategory.Setup(m => m.Categories).Returns(new List<Category> {
            //    new Category { Name = "Programming",Description =" Tijs category is for progeraming",UrlSlug = "Programing",},
            //    new Category { Name = "Animal",Description =" Tijs category is for progeraming",UrlSlug = "Animal" },
            //    new Category { Name = "Technology",Description =" Tijs category is for progeraming",UrlSlug = "Tech" }
            //});

            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.Posts).Returns(new List<Post> {
                new Post { Title = "Learn New MVC",Description = "YOu CAn LEAr new thing throught this tutorial",Meta ="Asp.Net",ShortDescription= "Very Little Tutorial of being " ,UrlSlug="Asp",PostedOn  = DateTime.Parse("2010-09-01") ,Modified = DateTime.Parse("2010-09-01")},
                new Post { Title = "Latest Python Snake", Description = "YOu CAn LEAr new thing throught this tutorial",Meta ="Python",ShortDescription= "Very Little Tutorial of being " ,UrlSlug="Python",PostedOn  = DateTime.Parse("2010-09-01") ,Modified = DateTime.Parse("2010-09-01")},
                new Post { Title = "New Generation og Mobile", Description = "YOu CAn LEAr new thing throught this tutorial",Meta="Mobile",ShortDescription= "Very Little Tutorial of being " ,UrlSlug="Java",PostedOn  = DateTime.Parse("2010-09-01"),Modified = DateTime.Parse("2010-09-01")  }
});
            kernel.Bind<IPostRepository>().ToConstant(mock.Object);

           
            // put bindings here 


        }


    }


}
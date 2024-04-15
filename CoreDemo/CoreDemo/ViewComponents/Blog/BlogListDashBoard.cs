using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashBoard: ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}

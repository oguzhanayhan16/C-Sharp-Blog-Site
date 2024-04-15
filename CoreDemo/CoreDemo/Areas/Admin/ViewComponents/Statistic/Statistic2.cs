using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v2 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogContent).Take(1).FirstOrDefault();
            ViewBag.j = c.Comments.Count();
            return View();
        }
    }
}

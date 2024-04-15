using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager (new EFBlogRepository ());
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.i = bm.GetList().Count();
            ViewBag.j = c.Contacts.Count();
            ViewBag.a = c.Comments.Count();

            string api = "e97bf8328b77c87c560305ee7bca8291";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Bursa&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load (connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
           return View();
        }
    }
}

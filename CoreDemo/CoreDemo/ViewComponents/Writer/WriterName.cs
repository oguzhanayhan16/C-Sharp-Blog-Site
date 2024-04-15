using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterName : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.v = userName;
            return View();
        }
       
    }
}

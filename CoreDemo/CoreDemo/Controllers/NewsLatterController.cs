using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLatterController : Controller
    {
        NewsletterManager nm = new NewsletterManager(new EFNewsletterRepository());
		[HttpGet]
		public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLatter p)
        {
            p.MailStatus = true;
            nm.AddNewsletter(p);
            return PartialView();
        }
    }
}

using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CoreDemo.Controllers
{
    public class DashBoardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
			var userName = User.Identity.Name;
			ViewBag.v = userName;
			var userMail = c.Users.Where(X => X.UserName == userName).Select(y => y.Email).FirstOrDefault();
			
            var writerId =c.Writers.Where(x => x.WriterMail == userMail).Select(y=>y.WriterID).FirstOrDefault();

            ViewBag.v1=c.Blogs.Count().ToString();
            ViewBag.v2 =c.Blogs.Where(x=>x.WriterID==1).Count(); 
            ViewBag.v3 =c.Categorys.Count().ToString(); 
            return View();
        }
    }
}

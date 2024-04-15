using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashBoard : ViewComponent
    {
        WriterManager vm = new WriterManager(new EFWriterRepository());
            Context c = new Context();



		public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.v = userName;
            var userMail=c.Users.Where(X => X.UserName == userName).Select(y=>y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            var values = vm.GetWriterByID(writerID);
            return View(values);
        }
    }
}

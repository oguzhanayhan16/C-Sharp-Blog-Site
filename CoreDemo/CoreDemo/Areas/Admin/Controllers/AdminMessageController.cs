using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Reposityory());
        Context cc = new Context();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = cc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = cc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            var values = mm.GetSendBoxWithMessageByWriter(writerID);
            return View(values);
        }


        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var userName = User.Identity.Name;
            var userMail = cc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = 7;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            mm.TAdd(p);
            return RedirectToAction("SendBox");
        }
    }
}

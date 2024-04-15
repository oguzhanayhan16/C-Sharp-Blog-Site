using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Context cc = new Context();
        Message2Manager mm = new Message2Manager(new EFMessage2Reposityory());
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

        public IActionResult MessageDetails(int id)
        {
           var values =mm.TGetByID(id);
            return View(values);

        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var userName = User.Identity.Name;
            var userMail = cc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            p.SenderID=writerID;
            p.ReceiverID = 7;
            p.MessageStatus = true;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("InBox");
        }

    }
}

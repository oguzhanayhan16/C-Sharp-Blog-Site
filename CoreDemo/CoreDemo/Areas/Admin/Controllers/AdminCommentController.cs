using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using DocumentFormat.OpenXml.Office2021.PowerPoint.Comment;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
        {
            var values = cm.GetCommentWithBlog();

            return View(values);
        }
    }
}

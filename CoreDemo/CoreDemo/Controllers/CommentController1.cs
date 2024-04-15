using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]

	public class CommentController1 : Controller
	{
		CommentManager cm = new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return  PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment p)
		{
			p.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogID = 10;
			cm.CommentAdd(p);
			return PartialView();
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}

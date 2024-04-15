using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comments
{
	public class CommentListByBlog : ViewComponent
	{
		CommentManager cm = new CommentManager(new EFCommentRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = cm.GetList(id);
			return View(values);
		}
	}
}

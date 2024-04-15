using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogLast3Post: ViewComponent
	{
		BlogManager bm = new BlogManager(new EFBlogRepository());

		public IViewComponentResult Invoke(int id)
		{
			var values = bm.GetLast3Blog();
			return View(values);
		}
	}
}

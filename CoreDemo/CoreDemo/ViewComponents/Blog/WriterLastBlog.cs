using BusinessLayer.Concrete;
using DataAccessLayer.Abstact;
using DataAccessLayer.EntitiyFramework;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog

{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EFBlogRepository());

		public IViewComponentResult Invoke(int id)
		{
			var values = bm.GetBlogListByWriter(1);
			return View(values);
		}
	}
}

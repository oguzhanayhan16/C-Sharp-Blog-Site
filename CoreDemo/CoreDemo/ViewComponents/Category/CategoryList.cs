using BusinessLayer.Concrete;
using DataAccessLayer.Abstact;
using DataAccessLayer.EntitiyFramework;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{

	public class CategoryList : ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EFCategoryRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = cm.GetList();
			return View(values);
		}

	}
}

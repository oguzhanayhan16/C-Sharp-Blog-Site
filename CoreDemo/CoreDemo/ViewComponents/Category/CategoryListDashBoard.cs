using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashBoard:ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EFCategoryRepository());
    public IViewComponentResult Invoke()
    {
        var values = cm.GetList();
        return View(values);
    }

    
    }
}

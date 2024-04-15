using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index(int page =1)
        {
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {

            CategoryValidator bv = new CategoryValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);


                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetByID(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}

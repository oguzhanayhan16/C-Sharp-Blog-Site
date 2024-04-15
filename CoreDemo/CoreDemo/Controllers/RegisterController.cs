using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager vm  = new WriterManager(new EFWriterRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer p )
		{
			WriterValidator validator = new WriterValidator();
			ValidationResult results =validator.Validate(p);
			if (results.IsValid) 
			{
				p.WriterStatus = true;
				p.WriterAbout = "Deneme Test";
				vm.TAdd(p);

				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
			
		}
	}
}

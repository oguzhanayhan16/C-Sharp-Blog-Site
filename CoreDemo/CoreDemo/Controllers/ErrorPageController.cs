using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1()
		{
			return View();
		}
	}
}

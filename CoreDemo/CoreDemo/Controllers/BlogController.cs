using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Authorization;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
        CategoryManager c = new CategoryManager(new EFCategoryRepository());
        Context cc = new Context();

        BlogManager cm = new BlogManager(new EFBlogRepository());
		

		public IActionResult Index()
		{
			var values = cm.GetBlogListWithCategory();
			return View(values); 
		}

		public IActionResult BlogReadAll(int id)
        {
			ViewBag.Id = id;
            var values = cm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter(int id)
        {
            var userName = User.Identity.Name;
            var userMail = cc.Users.Where(X => X.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
        
            var values =cm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryValues = (from x in c.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var userName = User.Identity.Name;
            var userMail=cc.Users.Where(x=>x.UserName==userName).Select(y=>y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();

            BlogValidatior bv = new BlogValidatior();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                cm.TAdd(p);


                return RedirectToAction("BlogListByWriter", "Blog");
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
       
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = cm.TGetByID(id);
            cm.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");

        }
        [HttpGet]

        public IActionResult EditBlog(int id)
        {
            var blogValue = cm.TGetByID(id);
            List<SelectListItem> categoryValues = (from x in c.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);

        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var userName = User.Identity.Name;
            var userMail = cc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = cc.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            cm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");

        }
    }
}

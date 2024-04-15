using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using CoreDemo.Models;
using System;
using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Identity;


namespace CoreDemo.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName)
                .FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> WriterEditProfile()
        {

       
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdaeViewModel p = new UserUpdaeViewModel();
            p.mail = values.Email;
            p.nameSurname = values.NameSurnamee;
            p.ImageUrl = values.ImageUrll;
            p.userName = values.UserName;
            return View(p);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdaeViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurnamee = p.nameSurname;
            values.ImageUrll =p.ImageUrl;
            values.Email = p.mail;
            if (!string.IsNullOrEmpty(p.password)) // Şifre alanı dolu ise
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
            }

            var result = await _userManager.UpdateAsync(values);


            return RedirectToAction("Index", "DashBoard");
            
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimageName = Guid.NewGuid + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImage", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterStatus = true;
            w.WriterPassword = p.WriterPassword;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "DashBoard");
        }

    }
}

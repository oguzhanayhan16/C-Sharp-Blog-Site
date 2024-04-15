﻿using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz.")]
        public string nameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string Password { get; set; }

        [Display(Name = "ŞifreTekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz.")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz.")]
        public string UserName { get; set; }
    }
}

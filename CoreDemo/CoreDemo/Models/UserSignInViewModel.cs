using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string password { get; set; }
    }
}

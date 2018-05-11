using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace NASEB.Library.MVCWebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adı zorunlu bir alandır.")]
        [Display(Name ="E Posta")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Paralo zorunlu bir alandır.")]
        [MinLength(5,ErrorMessage ="Parola en az 5 karaterden oluşmalıdır.")]
        public string Password { get; set; }
        [Display(Name ="Beni Hatırla")]
        public bool SaveMe { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Mevcut parola gereklidir.")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Yeni parola gereklidir.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Yeni parola tekrar gereklidir.")]
        [Compare("NewPassword",ErrorMessage = "Girilen parola yeni parola ile eşleşmiyor.")]
        public string RetypePassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class ResetUserResetPasswordModel
    {
        [MinLength(5, ErrorMessage = "Yeni parola en az 5 karaterden oluşmalıdır.")]
        [Required(ErrorMessage = "Yeni parola alanı zorunludur.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Yeni parola tekrar alanı zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Yeni parola ve tekrar alanı eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public int UserID { get; internal set; }
    }

    public class EditUserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage ="Adı soyad alanı zorunludur.")]
        [Display(Name ="Adı Soyadı")]
        [MaxLength(100, ErrorMessage = "Adı soyadı en fazla 100 karaterden oluşabilir.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "E Poasta  alanı zorunludur.")]
        [Display(Name = "E Posra")]
        [MaxLength(100,ErrorMessage ="E Posta en fazla 100 karaterden oluşabilir.")]
        [EmailAddress(ErrorMessage ="E Poas adresi geçersiz.")]
        public string EMail { get; set; }
    }
}

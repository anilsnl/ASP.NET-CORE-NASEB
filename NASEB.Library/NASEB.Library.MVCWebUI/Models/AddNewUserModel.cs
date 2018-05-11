using System;
using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class AddNewUserModel
    {
         [Required(ErrorMessage = "Kullanıcı adı soyadı zorunlu bir alandır.")]
         [Display(Name = "Adı Soyadı")]
         [MaxLength(100,ErrorMessage = "Ad soyad alanı en fazla 100 karaterden oluşabilir.")]
         public string NameSurname { get; set; }

        [Required(ErrorMessage = "Kullanıcı e posta adresi zorunlu bir alandır.")]
        [Display(Name = "E Posta Adresi")]
        [MaxLength(150,ErrorMessage = "E Posta alanı en fazla 150 karaterden oluşmalıdır.")]
        [EmailAddress(ErrorMessage = "Geçersiz bir e posta adresi girdiniz.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Parola zorunlu bir alandır.")]
        [Display(Name = "Parola")]
        [MinLength(5,ErrorMessage = "Parola en az 5 karaterden oluşmalıdır.")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Girilen parolalar eşleşmiyor.")]
        [Required(ErrorMessage = "Parola tekrar zorunlu bir alandır.")]
        [Display(Name = "Parola Tekrar")]
        [MinLength(5, ErrorMessage = "Parola en az 5 karaterden oluşmalıdır.")]
        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "E Posta adresi zorunludu.")]
        [EmailAddress(ErrorMessage = "Geçersiz E Posta adresi girdiniz")]
        [Display(Name = "E Posta")]
        public string EMail { get; set; }

        public bool isComplated { get; set; }
    }
}

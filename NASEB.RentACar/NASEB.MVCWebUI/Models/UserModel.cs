using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.MVCWebUI.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-mail adresi zorunlu bir alandır.")]
        [EmailAddress(ErrorMessage = "Geçersiz bir e-posta adresi girdiniz.")]
        [MaxLength(100)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int BranchID { get; set; }
        [Required(ErrorMessage = "Paralo zorunlu bir alandır.")]
        [MinLength(5, ErrorMessage = "Parola en az 5 karaterden oluşmalıdır.")]
        public string Parola { get; set; }
    }
}

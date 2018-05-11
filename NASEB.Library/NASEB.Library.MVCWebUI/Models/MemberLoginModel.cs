using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.Library.MVCWebUI.Models
{
    public class MemberLoginModel
    {
        [Required(ErrorMessage ="Üye ismi zorunludur.") ]
        [Display(Name ="Üye Adı")]
        public String Name { get; set; }
        [Required(ErrorMessage ="Üye soyismi zorunludur.")]
        [Display(Name="Üye Soyismi")]
        public String Surname { get; set; }
        [Required(ErrorMessage ="Üye doğum yılı zorunlu bir alandır.")]
        [Display(Name="Üye Doğum Yılı")]
        [Range(typeof(int), "1950", "2099", ErrorMessage = "Doğum yılı geçersiz.")]
        public int BirthYear { get; set; }
        [Required(ErrorMessage = "Uyruk zorunlu bir alandır.")]
        public String Citizenship { get; set; }

        [Required(ErrorMessage = "TC/YU Numarası zorunludur.")]
        [Display(Name = "TC/YU Numarası")]
        [Range(typeof(long),"00000000000","99999999999",ErrorMessage ="TC/YU Numarası 11 haneden oluşmalıdır.")]
        public long TRIDNo { get; set; }
        public string SaveMe { get; internal set; }
    }
}

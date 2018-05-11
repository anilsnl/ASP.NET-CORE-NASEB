using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class AddNewRentModel
    {
        [Display(Name = "Kitap")]
        public int BookID { get; set; }

        [Required (ErrorMessage ="Üye seçimi zorunludur.")]
        [Display(Name ="Üye")]
        public int MemberID { get; set; }
        [Required (ErrorMessage ="Başlangıç günü zorunlu bir alandır.")]
        [Display(Name ="Başlangıç Günü")]
        [Range(1, 31, ErrorMessage = "Geçersiz  gün değeri girdiniz.")]
        public int StartDay { get; set; }
        [Required (ErrorMessage ="Başlangıç ayı zorunlu bir alandır.")]
        [Display(Name ="Başlangıç Ayı")]
        [Range(1,12,ErrorMessage ="Geçersiz  ay değeri girdiniz.")]
        public int StartMonth { get; set; }
        [Required(ErrorMessage ="Başlangıç yılı zorunlu bir alandır.")]
        [Display(Name ="Başlangıç Yılı")]
        [Range(2017,2050,ErrorMessage ="Geçersiz yıl değeri girdiniz.")]
        public int StartYear { get; set; }
        [Required(ErrorMessage ="Kiralama süresi zorunlu bir alandır.")]
        [Display(Name = "Kaç Gün Kitap Kiralanacak")]
        [Range(0,60,ErrorMessage ="Geçersiz değer girdiniz.")]
        public int RentDayCount { get; set; }
    }
}

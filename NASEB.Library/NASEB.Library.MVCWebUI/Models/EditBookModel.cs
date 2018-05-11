using System;
using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class EditBookModel
    {
        
        public int BookID { get; set; }
        [Required(ErrorMessage = "Kitap adı zorunlu bir alandır.")]
        [Display(Name = "Kitap Adı")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "ISBN Numarası zorunlu bir alandır.")]
        [Display(Name = "ISBN")]
        [MaxLength(20)]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Sayfa numarası zorunlu bir alandır.")]
        [Display(Name = "Sayfa Numarası")]
        public int SayfaSayısı { get; set; }
        [Required(ErrorMessage = "Kitap türü zorunlu bir alandır.")]
        [Display(Name = "Kitap Türü")]
        public int BookTypeID { get; set; }

        [Required(ErrorMessage = "Uygun kitap sayısı zorunlu bir alandır.")]
        [Display(Name = "Uygun Kitap Sayısı")]
        public int AvailableQuantity { get; set; }
        [Required(ErrorMessage = "Toplam miktar zorunlu bir alandır.")]
        [Display(Name = "Toplam Miktar")]
        public int TotalQuantity { get; set; }
        [Required(ErrorMessage = "Yayın evi alanı zorunludur.")]
        [Display(Name = "Yayın Evi")]
        public int PublisherID { get; set; }
        [Required(ErrorMessage = "Yayım tarhi zorunlu bir alandır.")]
        [Display(Name = "Yayın Tarihi")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Kitap Özeti")]
        [MaxLength(2000, ErrorMessage = "Kitap özeti en fazla 2000 karakterden oluşabilir.")]
        public string BookSummary { get; set; }
        [Display(Name = "Konum")]
        [MaxLength(10, ErrorMessage = "Konum alanı geçersiz girildi.")]
        public string Location { get; set; }
    }
}

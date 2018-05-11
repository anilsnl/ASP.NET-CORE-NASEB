using NASEB.Entities.Abstruck;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASEB.Entities.Concrete
{
    public class Car:DbBaseLogger,IEntity
    {
        public int CarID { get; set; }
        [Required(ErrorMessage ="Araç modeli zorunlu bir alandır.")]
        [MaxLength(150,ErrorMessage ="Araç modeli 150 karakterden uzun olmamalıdır.")]
        [Display(Name = "Araç Modeli")]
        public string CarName { get; set; }
        [Required(ErrorMessage ="Araç plakası zorunlu bir alandır.")]
        [MaxLength(15,ErrorMessage = "Araç plakası 15 karakterden uzun olmamalıdır.")]
        [Display(Name ="Araç Plakası")]
        public string Plate { get; set; }
        [Required(ErrorMessage ="Aracın detayı zorunlu bir alandır.")]
        [MaxLength(200,ErrorMessage ="Araç detayı 200 karakterden uzun olmamalıdır.")]
        [Display(Name ="Araç Detayı")]
        public string Detail { get; set; }
        [Required(ErrorMessage ="Aracın ruhsat bilgisi zorunlu bir alandır.")]
        [Display( Name ="Araç Ruhsat Bilgileri")]
        public string LicenseInfo { get; set; }
        [Required(ErrorMessage = "Kayıt tarihi zorunlu bir alandır.")]
        [Display(Name ="Kayıt Tarihi")]
        public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage ="Aracın durumu zorunlu bir alandır.")]
        [Display(Name ="Aracın Durumu")]
        public int Status { get; set; }
        [Required(ErrorMessage ="Aracın bulunduğu şubeyi girmek zorunludur.")]
        [Display(Name ="Aracın Bulunduğu Şube")]
        public int ExistingBranchID { get; set; }
        [ForeignKey("ExistingBranchID")]
        public Branch ExistingBranch { get; set; }
    }
}

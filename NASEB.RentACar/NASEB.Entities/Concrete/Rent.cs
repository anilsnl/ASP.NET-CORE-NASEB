using NASEB.Entities.Abstruck;
using System;
using System.ComponentModel.DataAnnotations;

namespace NASEB.Entities.Concrete
{
    public class Rent :DbBaseLogger,IEntity
    {
        public int RentID { get; set; }
        [Required(ErrorMessage = "Araç zorunlu alandır")]
        [Display(Name = "Kiralanan Araç")]
        public int CarID { get; set; }
        [Required(ErrorMessage ="Kıralanan şube boş bırakılamaz")]
        public int RentBranchID { get; set; }
        [Display(Name = "Kıralanan Müşteri")]
        [Required(ErrorMessage ="Kıralanan müşteri zorunlu bir alandır.")]
        public int CustomerID { get; set; }
        [Display(Name ="Kıralanan Şirket")]
        public int? CompanyID { get; set; }
        [Required]
        [Display(Name = "Ticari mi")]
        public bool isCommercial { get; set; }
        [Required(ErrorMessage = "Kayıt başlangınç tarihi zorunlu alandır")]
        [Display(Name ="Kayıt başlangınç tarihi")]
        public DateTime RentStartDate { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage ="Kira bitiş tarihi zorumlu bir alandır.")]
        [Display(Name="Kira biriş arihi")]
        public DateTime RentEndDate { get; set; }
        [Display(Name = "Gecikme arihi")]
        public DateTime? DeliveredDate { get; set; }
        [Display(Name = "Kira Gün Sayısı")]
        public int RentDay { get; set; }
        [Display(Name="Toplam kira fiyatı")]
        [Required(ErrorMessage ="Toplam kira tutarı zorunlu bir alandır.")]
        public double TotalRentPrice { get; set; }
        [Display(Name ="Hasar")]
        public double? DamagePrice { get; set; }
        [Display(Name = "Gecikme Cezası")]
        public double? DelayFine { get; set; }
        [Display(Name = "Trafik Cezası")]
        public double? TrafficTicket { get; set; }
        [Required(ErrorMessage = "Kalan borç zorunlu bir alandır.")]
        [Display(Name = "Kalan Borç")]
        public double? RemaindDebt { get; set; }
        [Required]
        [Display(Name ="Kiralama Tamamalandı")]
        public bool isComplate { get; set; }
        [Required]
        [Display(Name ="Tüm Borç Kapatıldı")]
        public bool PaymentComplate { get; set; }
        [Required(ErrorMessage ="Teslim edilecek şube zorunlu bir alandır.")]
        [Display(Name ="Teslim Edilecek Şube")]
        public int DeliveredBranchID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
        public virtual Car Car { get; set; }
       
        public virtual Branch DeliveredBranch { get; set; }
        public virtual Branch RentBranch { get; set; }
    }
}

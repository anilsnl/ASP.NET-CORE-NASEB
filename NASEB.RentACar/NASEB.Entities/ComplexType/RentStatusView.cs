using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NASEB.Entities.ComplexType
{
    public class RentStatusView:IEntity
    {
        public int RentID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        [Display(Name ="Plaka")]
        public string Plate { get; set; }
        [Display(Name ="Araç Tanımı")]
        public string CarName { get; set; }
        [Display(Name ="Müşteri Adı")]
        public string CustomerName { get; set; }
        [Display(Name ="Şirket Adı")]
        public string CompanyName { get; set; }
        [Display(Name ="Kiralayan Şube")]
        public string RentingBranch { get; set; }
        [Display(Name ="Teslim Edilecek Şube")]
        public string DeliveredBranch { get; set; }
        [Display(Name ="Kira Tarihi")]
        public DateTime RentDate { get; set; }
        [Display(Name ="Kira Bitiş Tarihi")]
        public DateTime RentEndDate { get; set; }
        [Display(Name ="Kalan Süre")]
        public int RemaindedHour { get; set; }
        [Display(Name ="Gecikme")]
        public bool isLate { get; set; }

    }
}

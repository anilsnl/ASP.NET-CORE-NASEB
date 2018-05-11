using System;
using System.ComponentModel.DataAnnotations;

namespace NASEB.Entities.ComplexType
{
    public class RentOverviewView
    {
        public int RentID { get; set; }
        public int MemberID { get; set; }
        
        [Display(Name ="Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Beklenen Son. Trh.")]
        public DateTime ExpactedEndDate { get; set; }

        [Display(Name = "Üye Adı Soyadı")]
        public string MemberNameSurname { get; set; }

        [Display(Name = "Üye Telefon")]
        public string MemberPhoneNumber { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; }
        public bool isRentingCompleted { get; set; }
        public string BookName { get; set; }
    }
}
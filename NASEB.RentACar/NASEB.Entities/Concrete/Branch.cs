using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class Branch:IEntity
    {
        public int BranchID { get; set; }
        [Required(ErrorMessage ="Şube adı zorunlu alandır.")]
        [MaxLength(150,ErrorMessage ="Şube adı en fazla 150 karakterden oluşabilir.")]
        [Display(Name ="Şube Adı")]
        public string BranchName { get; set; }
        [Required(ErrorMessage ="Şube adresi zorunlu bir alandır.")]
        [MaxLength(250,ErrorMessage ="Şube adresi en fazla 250 karakterden oluşabilir.")]
        [Display(Name ="Şube Adresi")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Telefon numarası zorunlu bir alandır.")]
        [MaxLength(15,ErrorMessage ="Telefon numarası en fazla 15 karakterden oluşabilir.")]
        [Display(Name ="Telefon Numarası")]
        public string Phone { get; set; }
        [InverseProperty("ExistingBranch")]
        public virtual List<Car> ExistingCars { get; set; }
        [InverseProperty("DeliveredBranch")]
        public virtual List<Rent> DeliveredRents { get; set; }
        [InverseProperty("Branch")]
        public virtual List<NASEBUser> Employees { get; set; }
     

    }
}

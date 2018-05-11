using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class Company:DbBaseLogger,IEntity
    {
        public int CompanyID { get; set; }
        [Required(ErrorMessage ="Şirket ismi zorunlu bir alandır.")]
        [MaxLength(200,ErrorMessage ="Şirket ismi en fazla 200 karakterden oluşmalıdır.")]
        [Display(Name ="Şirket İsmi")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage ="Vergi numarası zorunlu bir alandır.")]
        [MaxLength(15, ErrorMessage ="Vergi numarası en fazla 15 karakterden oluşmalıdır.")]
        [Display(Name ="Vergi Numarası")]
        public string TaskNumber { get; set; }
        [Required(ErrorMessage = "Vergi dairesi zorunlu bir alandır.")]
        [MaxLength(100, ErrorMessage ="Vergi dairesi en fazla 100 karakterden oluşmalıdır.")]
        [Display(Name ="Vergi Dairesi")]
        public string TaskAdministration { get; set; }
        [Required(ErrorMessage ="Ticari sicil numarası zorunlu bir alandır.")]
        [MaxLength(20,ErrorMessage ="Ticari sicil numarası en fazla 20 karakterden oluşmalıdır.")]
        [Display(Name ="Ticaret Sicil Numarası")]
        public string TradeRegisterNumber { get; set; }
        [Required(ErrorMessage ="Adres zorunlu bir alandır.")]
        [MaxLength(500,ErrorMessage ="Adres alanı en fazla 500 karakterden oluşabilir.")]
        [Display(Name ="Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Telefon numarası zorunlu bir alandır.")]
        [MaxLength(15,ErrorMessage ="Telefon alanı en fazla 15 karakterden oluşabilir.")]
        [Display(Name ="Telefon")]
        public string Phone { get; set; }
        [MaxLength(15)]
        [Display(Name ="Diğer Telefon")]
        public string OtherPhone { get; set; }
        [MaxLength(15,ErrorMessage ="Fax en fazla 15 karakterten oluşabilir.")]
        [Display(Name ="Faks numarası")]
        public string Fax { get; set; }
        [MaxLength(200,ErrorMessage ="Yetkili ismi en fazla 200 karakterden oluşmalıdır.")]
        [Required(ErrorMessage ="Yetkili ismi zorunlu bir alandır.")]
        [Display(Name ="Yetkili Adı Soyadı")]
        public string AuthorizedName { get; set; }
        [Required]
        [Display(Name ="Aktif mi")]
        public bool isActive { get; set; }
        [InverseProperty("Company")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
       
        public Company()
        {
            Customers = new HashSet<Customer>();
            Rents = new HashSet<Rent>();
        }
    }
}

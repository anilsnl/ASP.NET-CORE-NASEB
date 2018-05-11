using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class Customer:DbBaseLogger,IEntity
    {

        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Müşteri adı zorunlu bir alandır.")]
        [MaxLength(100,ErrorMessage ="Müşteri adı en fazla 100 karakter olmalıdır.")]
        [Display(Name="Müşter Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Müşteri soyadı zorunlu bir alandır.")]
        [MaxLength(100,ErrorMessage ="Müşteri soyadı en fazla 100 karakter olmalıdır.")]
        [Display(Name ="Müşteri Soyadı")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Müşteri doğum tarihi zorunlu bir alandır.")]
        [Display(Name="Müşteri Doğum Tarihi")]
        public int BirthDate { get; set; }
        [Range(typeof(long),"000000000000","99999999999",ErrorMessage ="T.C. Kimlik numarası 11 karakterden oluşmalıdır.")]
        [Display(Name ="Müşteri T.C.kimlik numarası")]
        public long? TRIDNo { get; set; }
        [Display(Name ="Müşteri pasaport numarası")]
        public string PasportNumber { get; set; }
        [Required(ErrorMessage ="kayıt tarihi zorunlu bir alandır.")]
        [Display(Name ="Kayıt Tarihi")]
        public DateTime RegisterDate { get; set; }
        [Required,Display(Name ="kurumsal mı")]
        public bool isCorporate { get; set; }
        [Required(ErrorMessage ="Vatandaş mısın")]
        [Display(Name ="Vatandaş mı")]
        public bool isTRCitizen { get; set; }
        [Required]
        [Display(Name ="Vatandaşlık Doğrulandımı")]
        public bool isTRIDVerified { get; set; }
        [Display(Name="Bağlı Şirket")]
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public Customer()
        {
            Rents = new HashSet<Rent>();
        }

    }
}

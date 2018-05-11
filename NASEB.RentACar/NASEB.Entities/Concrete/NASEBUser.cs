using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class NASEBUser:IEntity
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [MaxLength(50, ErrorMessage ="İsim en fazla 50 karakterden oluşabilir.")]
        [Display(Name="İsim")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Soyisim alanı zorunludur.")]
        [MaxLength(50,ErrorMessage ="Soyisim en fazla 50 karakterden oluşabilir.")]
        [Display(Name="Soyisim")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="E-mail adresi zorunlu bir alandır.")]
        [EmailAddress(ErrorMessage ="Geçersiz bir e-posta adresi girdiniz.")]
        [MaxLength(100)]
        [Display(Name="E-Posta")]
        public string EMail { get; set; }
        [Required(ErrorMessage ="Telefon numarası en fazla 15 karakter olabilir.")]
        [MaxLength(15,ErrorMessage ="Cep telefonu 15 karaterden oluşmalıdır.")]
        [MinLength(10,ErrorMessage ="Geçersiz Cep telefonu girdiniz.")]
        [Display(Name="Cep Telefonu")]
        public string PhoneNumber { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [Display(Name ="Aktif mi")]
        public bool isActive { get; set; }
        [Required(ErrorMessage ="Adres zorunlu bir alandır.")]
        [Display(Name="Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Doğum tarihi zorunlu bir alandır!")]
        [Display(Name="Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage ="Şube seçimi zorunludur.")]
        [Display(Name="Şube")]
        public int BranchID { get; set; }
        [Required(ErrorMessage ="Kayıt Tarihi zorunlu bir alandır.")]
        [Display(Name="Kayıt Tarihi")]
        public DateTime RegisterDate { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
     
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public NASEBUser()
        {
            Logs = new HashSet<Log>();
        }
    }
}

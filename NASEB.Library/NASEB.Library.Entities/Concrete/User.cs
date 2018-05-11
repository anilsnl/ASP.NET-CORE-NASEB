using NASEB.Library.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASEB.Library.Entities.Concrete
{
    public class User:BaseEntity,IEntity
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Adı soyadı zorunludur.")]
        [Display(Name ="Adı Soyadı")]
        public string NameSurname { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage ="E-Posta zorunludur.")]
        [EmailAddress(ErrorMessage ="Geçersiz E-Posta girişi.")]
        [MaxLength(150,ErrorMessage ="E Posta en fazla 150 karaterden oluşabilir.")]
        public string EMail { get; set; }
        
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RentHistory> Rents { get; set; }
   //     [InverseProperty("User")]
        public virtual ICollection<Member> Members { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserToken> Tokens { get; set; }

        public User()
        {
            UserRoles = new HashSet<UserRoles>();
            Rents = new HashSet<RentHistory>();
            Members = new HashSet<Member>();
            Tokens = new HashSet<UserToken>();
        }
    }
}

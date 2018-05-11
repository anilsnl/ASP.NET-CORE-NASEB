using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class NASEBRole:IEntity
    {
        [Key]
        public int RoleID { get; set; }
        [Required(ErrorMessage ="Müsteri rol ismi zorunlu alandır.")]
        [Display(Name ="Rol isimi")]
        [MaxLength(20,ErrorMessage ="Rol adı en fazla 20 karakter olabilir.")]
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        
    }
}

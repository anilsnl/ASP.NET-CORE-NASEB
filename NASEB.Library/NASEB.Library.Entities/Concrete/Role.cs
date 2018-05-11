using System.Collections;
using System.Collections.Generic;
using NASEB.Library.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace NASEB.Library.Entities.Concrete
{
    public class Role:IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        [Required(ErrorMessage ="Role adı zorunludur.")]
        [Display(Name ="Rol Adı")]
        [MaxLength(10,ErrorMessage ="Rol adı en fazla 10 karakterden oluşabilir.")]
        public string RoleName { get; set; }
        
        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public Role()
        {
            UserRoles=new HashSet<UserRoles>();
        }
    }
}

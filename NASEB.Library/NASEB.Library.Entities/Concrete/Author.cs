using NASEB.Library.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace NASEB.Library.Entities.Concrete
{

    public class Author :IEntity
    {
        [Key,DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }
        [Required(ErrorMessage ="Yazar ismi zorunlu bir alandır.")]
        [Display(Name ="Yazar İsmi")]
        [MaxLength(200,ErrorMessage ="Yazar ismi en fazla 200 karakterden oluşabilir.")]
        public string NameSurname { get; set; }
 
        public virtual ICollection<AuthorBooks> AuthorBookses { get; set; }
      

    }

   
}

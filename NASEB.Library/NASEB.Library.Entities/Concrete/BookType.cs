using NASEB.Library.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASEB.Library.Entities.Concrete
{
    public class BookType:BaseEntity,IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookTypeID { get; set; }
        [Required(ErrorMessage ="Tür adı zorunlu bir alandır.")]
        [Display(Name ="Tür Adı")]
        [MaxLength(20,ErrorMessage ="Tür adı en fazla 20 karaterden oluşabilir.")]
        public string TypeName { get; set; }
        [InverseProperty("BookType")]
        public virtual ICollection<Book> Books { get; set; }

        public BookType()
        {
            Books =new HashSet<Book>();
        }
    }
}

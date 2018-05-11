using NASEB.Library.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASEB.Library.Entities.Concrete
{
    public class Publisher : BaseEntity,IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherID { get; set; }
        [Required(ErrorMessage ="Yayın evi  alanı zorunludur.")]
        [MaxLength(100,ErrorMessage ="Yayın evi alanı en fazla 100 karaterden oluşabilir.")]
        [Display(Name ="Yayın Evi")]
        public string PublisherName { get; set; }
        [InverseProperty("Publisher")]
        public virtual ICollection<Book> Books { get; set; }
        public Publisher()
        {
            Books = new HashSet<Book>();
        }
    }
}

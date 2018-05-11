using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class Log:IEntity
    {
        [Key]
        public Guid LogID { get; set; }
        [Required(ErrorMessage ="Tarih zorunlu alandır.")]
        [Display(Name ="Tarih")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Açıklama zorunlu alandır.")]
        [Display(Name ="İşlem Açıklama")]
        public string Detail { get; set; }

        [Required(ErrorMessage ="kişi numarası zorunlu alandır"),Display(Name ="kişi numarası")]
        public int UserID { get; set; }
        public virtual NASEBUser User { get; set; }


    }
}

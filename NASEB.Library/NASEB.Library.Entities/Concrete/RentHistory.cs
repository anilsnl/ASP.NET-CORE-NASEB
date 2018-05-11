using NASEB.Library.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASEB.Library.Entities.Concrete
{
    public class RentHistory:BaseEntity,IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentID { get; set; }
        [Required(ErrorMessage ="Kira başlangıç tarihi zorunludur.")]
        [Display(Name ="Kıra Başlangıç Tarihi")]
        public DateTime RentDate { get; set; }
        [Required(ErrorMessage = "Kira Bitiş tarihi zorunludur.")]
        [Display(Name = "Kıra Bitiş Tarihi")]
        public DateTime RentEndDate { get; set; }

        public int DelayedDayCount { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        [Required,Display(Name ="Gecikti")]
        public bool isDelayed { get; set; }

        [Display(Name ="Teslim Tarihi")]
        public DateTime? DeliveredDate { get; set; }

        [Display(Name ="Gecikme Cezası")]
        [Required]
        public double DelayFine { get; set; }

        [Display(Name ="Kiralama Tamamlandı")]
        public bool isRentingCompleted { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
    }
}

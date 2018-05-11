using NASEB.Library.Entities.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Converters;

namespace NASEB.Library.Entities.Concrete
{
    public class Member:BaseEntity,IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        [Required(ErrorMessage ="Üye soyadı zorunludur.")]
        [Display(Name ="Üye Soyadı")]
        [MaxLength(50,ErrorMessage ="Üye soyadı en fazla 50 karater olabilir.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Üye adı zorunludur.")]
        [Display(Name = "Üye Adı.")]
        [MaxLength(50, ErrorMessage = "Üye adı en fazla 50 karater olabilir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "T.C. Kimlik numarası zorunludur.")]
        [Range(typeof(long),"11111111111","99999999999",ErrorMessage ="T.C. Kimlik numarası 11 karater olmalıdır.")]
        [Display(Name ="T.C. KKimlik Numarası")]
        public long TRIDNo { get; set; }
        [Required(ErrorMessage ="Doğum tarihi zorunludur.")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Türk Vatabdaşı")]
        public bool isTRCitezen { get; set; }
        [Display(Name ="Vatandaşlık Doğrulandı.")]
        public bool isTRIDCitizenVerfied { get; set; }
        [Required(ErrorMessage ="Üye durumu zorunludur.")]
        [Display(Name ="Kiralaya Bilir")]
        public bool AwaableToRent { get; set; }
        [Display(Name = "Kalan Kira Hakkı")]
        [Range(typeof(int),"0","50",ErrorMessage = "Geçersiz değer girildi!")]
        public int RemainedRentConut { get; set; }
        [Display(Name = "Toplam Kira Hakkı")]
        [Range(typeof(int), "0", "50", ErrorMessage = "Geçersiz değer girildi!")]
        public int TotalRentConut { get; set; }

        [Required(ErrorMessage ="Telefon numarası zorunlu bir alandır.")]
        [Display(Name ="Telefon Numarası")]
        [MaxLength(15,ErrorMessage ="Telefon numarası en fazla 15 karaterden oluşabilir.")]
        [MinLength(10,ErrorMessage ="Telefon numarası en az 10 karaterden oluşabilir.")]
        public string PhoneNumber { get; set; }
        public bool isPhoneNumberVerified { get; set; }

        [Display(Name = "Adres")]
        [MaxLength(150, ErrorMessage = "Adres en fazla 150 karaterden oluşabilir.")]
        [MinLength(10, ErrorMessage = "Adres en az 10 karaterden oluşabilir.")]
        public string Address { get; set; }
        public bool isAddressVerified { get; set; }

        [Display(Name ="E Posta Adresi")]
        [Required(ErrorMessage ="E Posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage ="Geçersiz e posta adresi girdiniz.")]
        [MaxLength(150,ErrorMessage ="E Posta adresi en fazla 150 karaterden oluşabilir.")]
        public string EMail { get; set; }

        [Display(Name ="E Posta Doğrulandı")]
        public bool isEMailVerified { get; set; }


        [Required,Display(Name ="Kayın Eden")]
        public int UserID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public MemberStatusType Status { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<RentHistory> Rents { get; set; }
        public Member()
        {
            Rents = new HashSet<RentHistory>();
        }

    }

    public enum MemberStatusType
    {
        Acitive,Suspanded,Unsubscribed
    }
}

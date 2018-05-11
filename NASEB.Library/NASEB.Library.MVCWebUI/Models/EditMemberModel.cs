﻿using System.ComponentModel.DataAnnotations;

namespace NASEB.Library.MVCWebUI.Models
{
    public class EditMemberModel
    {
        [Required(ErrorMessage = "Üye adı zorunlu bir alandır.")]
        [Display(Name = "Üye Adı")]
        [MaxLength(50, ErrorMessage = "Ad alanı en fazla 50 karaterden oluşabilir.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Kullanıcı soyadı zorunlu bir alandır.")]
        [Display(Name = "Üye Soyadı")]
        [MaxLength(100, ErrorMessage = "Soyad alanı en fazla 50 karaterden oluşabilir.")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Kullanıcı adı soyadı zorunlu bir alandır.")]
        [Display(Name = "T.C. Kimlik No")]
        [Range(typeof(long), "00000000000", "99999999999", ErrorMessage = "T.C. Kimlik numarası 11 karater olmalıdır.")]
        public long TRIDNo { get; set; }


        [Required(ErrorMessage = "Cep telefonu soyadı zorunlu bir alandır.")]
        [Display(Name = "Cep Telefonu")]
        [MaxLength(15, ErrorMessage = "Cep telefonu alanı en fazla 15 karaterden oluşabilir.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E Posta Adresi")]
        [MaxLength(150, ErrorMessage = "E Posta alanı en fazla 150 karaterden oluşmalıdır.")]
        [EmailAddress(ErrorMessage = "Geçersiz bir e posta adresi girdiniz.")]
        public string EMail { get; set; }

        [Display(Name = "Doğum Yılı")]
        [Required(ErrorMessage = "Doğum yılı zorunlu bir alandır.")]
        [Range(1940, 2100, ErrorMessage = "Geçersiz yıl girdiniz.")]
        public int BirthYear { get; set; }

        [Display(Name = "Max Kitap Kiraliyabilme Hakkı")]
        [Required(ErrorMessage = "Max kitap kiraliyabilme hakkı zorunludur..")]
        [Range(0, 50, ErrorMessage = "Geçersiz değer girdiniz.")]
        public int MaxRentLimit { get; set; }

        public string isActive { get; set; }
        public bool VerifyREID { get; set; }


        [Display(Name = "Adres")]
        [MaxLength(150, ErrorMessage = "Adres en fazla 150 karaterden oluşabilir.")]
        [MinLength(10, ErrorMessage = "Adres en az 10 karaterden oluşabilir.")]
        public string Address { get; set; }
        public string isAddressVerified { get; set; }
        public int MemberID { get; set; }
    }
}

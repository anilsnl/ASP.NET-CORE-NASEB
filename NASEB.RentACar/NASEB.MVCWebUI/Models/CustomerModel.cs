using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.MVCWebUI.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Adres alanı zorunludur")]
        public string Adress { get; set; }
        [Required(ErrorMessage ="Telefon numarası zorunludur")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Müşteri adı zorunludur")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Müşteri soyadı zorunludur")]
        public string CustomerSurname { get; set; }
        [Range(11111111111,99999999999,ErrorMessage ="T.C. no 11 karaterden oluşmalıdır.")]
        public long TRIDNO { get; set; }
        public string PasaportNumber { get; set; }
        [Range(1950,2100,ErrorMessage ="Lütfen geçerli bir yıl girin.")]
        public int BirthDate { get; set; }
        public int UserID { get; set; }
    }
}

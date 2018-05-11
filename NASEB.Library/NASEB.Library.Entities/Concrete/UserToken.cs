using System;
using NASEB.Library.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NASEB.Library.Entities.Concrete
{
    public class UserToken:IEntity
    {
        [Key]
        public Guid TokenID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Token { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UseStartDate { get; set; }
        [Required]
        public DateTime TimeOutDate { get; set; }
        [Required]
        public bool isUsed { get; set; }
        [Required]
        public int UserID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public TokenTypes TokenType { get; set; }

        public virtual User User { get; set; }

    }
    public enum TokenTypes
    {
        Login,
        ResetPassword,
        FirstActivation
    }
}

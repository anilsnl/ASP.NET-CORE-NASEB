using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASEB.Library.Entities.Concrete
{
    public abstract class BaseEntity
    {
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }
    }
}

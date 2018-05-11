using System.ComponentModel.DataAnnotations;

namespace NASEB.Entities.Concrete
{
    public abstract class DbBaseLogger
    {
        [Required]
        public int UserID { get; set; }
        public NASEBUser User { get; set; }
    }
}

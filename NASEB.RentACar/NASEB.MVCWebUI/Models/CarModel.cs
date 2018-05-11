using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.MVCWebUI.Models
{
    public class CarModel
    {
        public string CarName { get; set; }
        public string Plate { get; set; }
        public string Details { get; set; }
        public string LicenseInfo { get; set; }
        public int Status { get; set; }
        public int ExistingBranchID { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
    }
}

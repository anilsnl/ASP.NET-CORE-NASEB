using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.Entities.ComplexType
{
    public class CarBranchView
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string Details { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string LicenseInfo { get; set; }
        public string Plate { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}

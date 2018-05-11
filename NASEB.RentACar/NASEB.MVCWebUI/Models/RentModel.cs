using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.MVCWebUI.Models
{
    public class RentModel
    {
        public int RentID { get; set; }
        public int CompanyID { get; set; }
        public int CustomerID { get; set; }
        public int DamagePrice { get; set; }
        public int DelayFine { get; set; }
        public int RentBranchID { get; set; }
        public int TotalRentPrice { get; set; }
        public int RemainDebt { get; set; }
        public int CarID { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
    }
}

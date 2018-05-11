using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.Entities.ComplexType
{
    public class RentCustomerBranchUserView
    {
        public int RentID { get; set; }
        public int UserID { get; set; }
        public int BranchID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public string CarName  { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public double? DamagePrice { get; set; }
        public double? DelayFine { get; set; }
        public double TotalRentPrice { get; set; }
        public double? RemainDebt { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public int HowManyDays { get; set; }
    }
}

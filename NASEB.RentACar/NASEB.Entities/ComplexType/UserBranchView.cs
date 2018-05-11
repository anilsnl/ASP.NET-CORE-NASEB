using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.Entities.ComplexType
{
    public class UserBranchView
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PasswordHash { get; set; }

    }
}

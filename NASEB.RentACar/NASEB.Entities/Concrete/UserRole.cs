using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int UserID { get; set; }
        public int RoleID  { get; set; }

        public NASEBUser User { get; set; }
        public NASEBRole Role { get; set; }
    }
}

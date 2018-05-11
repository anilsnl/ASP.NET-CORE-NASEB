using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.MVCWebUI.Models
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string EskiSifre { get; set; }
        public string YeniSifre { get; set; }
    }
}

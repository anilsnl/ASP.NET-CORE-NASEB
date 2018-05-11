using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.Entities.ComplexType
{
    public class LoginResult
    {
        public bool isSuccess { get; set; }
        public LoginResults Result { get; set; }
    }
    public enum LoginResults{
        InvalidUser,isSuccess,NotActiveAccount
    }
}

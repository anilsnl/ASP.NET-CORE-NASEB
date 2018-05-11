using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.Library.Helper.Mail
{
    public class MailModel
    {
        public List<string> Mails { get; set; }
        public string Subject { get; set; }
        public string MailContent { get; set; }
        public MailTypes MailType { get; set; }
        public MailModel()
        {
            Mails=new List<string>();
        }
    }

    public enum MailTypes
    {
        ResetOrActivation,
        Standard,
        StandardWithMulipmeReciver
    }
}

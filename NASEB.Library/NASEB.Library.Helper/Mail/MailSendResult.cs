using System.Collections.Generic;

namespace NASEB.Library.Helper.Mail
{
    public class MailSendResult
    {
        public string RefCode { get; set; }
        public string URL { get; set; }
        public bool SendSuccess { get; set; }
        public List<string> Errors { get; set; }

        public MailSendResult()
        {
            Errors=new List<string>();
        }
    }
}

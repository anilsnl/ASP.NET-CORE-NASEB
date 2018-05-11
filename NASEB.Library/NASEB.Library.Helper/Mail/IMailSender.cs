using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NASEB.Library.Helper.Mail
{
    public interface IMailSender
    {
        Task<MailSendResult> SendMailAsync(MailModel model);
    }

    public class MailSender : IMailSender
    {
        private IConfiguration Configuration;

        public MailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<MailSendResult> SendMailAsync(MailModel model)
        {
            
            SmtpClient client = new SmtpClient(Configuration["MailManager:smtp"]);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(Configuration["MailManager:email"], Configuration["MailManager:password"]);
            var result = new MailSendResult();


            try
            {
                MailMessage mailMessage = new MailMessage();
                if (model.Mails.Count==0)
                {
                    throw new Exception("Mails to sent could not be found!");
                }

                foreach (var item in model.Mails)
                {
                    mailMessage.To.Add(item);
                }

                string subContent = Configuration["MailManager:baseurl"];
                switch (model.MailType)
                {
                    case MailTypes.ResetOrActivation:
                        var token = Guid.NewGuid().ToString();
                        subContent = subContent+"/Reset/"+token;                       
                        break;
                    case MailTypes.Standard:
                        break;
                    case MailTypes.StandardWithMulipmeReciver:
                        break;
                }
                mailMessage.Body = model.MailContent;
                mailMessage.Subject = model.Subject;
                await client.SendMailAsync(mailMessage);

                return result;
            }
            catch (Exception e)
            {                
                result.SendSuccess = false;
                result.Errors.Add(e.Message);
                return result;
            }
        }
    }
}

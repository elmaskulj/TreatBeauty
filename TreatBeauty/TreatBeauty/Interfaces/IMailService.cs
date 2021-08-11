using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace TreatBeauty.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
    public class SendGridMailService : IMailService
    {
        public IConfiguration Configuration { get; }
        public SendGridMailService(IConfiguration config)
        {
            Configuration = config;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            try
            {
                Environment.SetEnvironmentVariable("SENDGRID_API_KEY", Configuration.GetSection("ApiKey").Value);
                var apikey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var client = new SendGridClient(apikey);
                var from = new EmailAddress("elmaskulj99@outlook.com","TreatBeauty");
                var to = new EmailAddress(toEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }



}

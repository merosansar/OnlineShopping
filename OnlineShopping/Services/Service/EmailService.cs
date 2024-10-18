//using MimeKit;
//using MailKit.Net.Smtp;  // Use MailKit's SmtpClient
//using OnlineShopping.Web.Services.IService;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;

//namespace OnlineShopping.Web.Services.Service
//{
//    public class EmailService(IConfiguration configuration) : IEmailService
//    {
//        private readonly IConfiguration _configuration = configuration;

//        public async Task SendEmailAsync(string email, string subject, string message)
//        {
//            var emailMessage = new MimeMessage();
//            emailMessage.From.Add(new MailboxAddress("OnlineShopping", "prabhupaypooja@gmail.com"));
//            emailMessage.To.Add(new MailboxAddress("", email));
//            emailMessage.Subject = subject;
//            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
//            {
//                Text = message
//            };

//            using (var client = new MailKit.Net.Smtp.SmtpClient())
//            {
//                await client.ConnectAsync(_configuration["EmailSetting:SmtpServer"], int.Parse(_configuration["EmailSetting:SmtpPort"]), true);
//                await client.AuthenticateAsync(_configuration["EmailSetting:Username"], _configuration["EmailSetting:Password"]);

//                await client.SendAsync(emailMessage);
//                await client.DisconnectAsync(true);
//            }
//        }
//    }
//}


//using MimeKit;
//using MailKit.Net.Smtp;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;
//using OnlineShopping.Web.Services.IService;

//namespace OnlineShopping.Web.Services.Service
//{
//    public class EmailService : IEmailService
//    {
//        private readonly IConfiguration _configuration;

//        public EmailService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task SendEmailAsync(string email, string subject, string message)
//        {
//            var emailMessage = new MimeMessage
//            {
//                From = { new MailboxAddress(_configuration["EmailSetting:FromName"], _configuration["EmailSetting:From"]) },
//                To = { new MailboxAddress("", email) },
//                Subject = subject,
//                Body = new TextPart(MimeKit.Text.TextFormat.Html)
//                {
//                    Text = message
//                }
//            };

//            try
//            {
//                using (var client = new SmtpClient())
//                {
//                    // Connect to the SMTP server
//                    await client.ConnectAsync(_configuration["EmailSetting:SmtpServer"], int.Parse(_configuration["EmailSetting:SmtpPort"]), true);

//                    // Authenticate
//                    await client.AuthenticateAsync(_configuration["EmailSetting:Username"], _configuration["EmailSetting:Password"]);

//                    // Send email
//                    await client.SendAsync(emailMessage);

//                    // Disconnect
//                    await client.DisconnectAsync(true);
//                }
//            }
//            catch (Exception ex)
//            {
//                // Log or handle the exception as needed
//                // e.g., log the error using a logging framework
//                throw new ApplicationException("An error occurred while sending the email.", ex);
//            }
//        }
//    }
//}

using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MailKit.Security;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Services.Service
{
    public class EmailService(IConfiguration configuration) : IEmailService
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage
            {
                From = { new MailboxAddress(_configuration["EmailSetting:FromName"], _configuration["EmailSetting:From"]) },
                To = { new MailboxAddress("", email) },
                Subject = subject,
                Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                }
            };

            try
            {
                using var client = new SmtpClient();
                // Connect to the SMTP server using SSL
                await client.ConnectAsync(_configuration["EmailSetting:SmtpServer"], int.Parse(_configuration["EmailSetting:SmtpPort"]??"0"), SecureSocketOptions.SslOnConnect);

                // Authenticate
                await client.AuthenticateAsync(_configuration["EmailSetting:Username"], _configuration["EmailSetting:Password"]);

                // Send email
                await client.SendAsync(emailMessage);

                // Disconnect
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new ApplicationException("An error occurred while sending the email.", ex);
            }
        }
    }
}
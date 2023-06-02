using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Diagnostics;
using MailKit.Net.Smtp;

namespace WebApi.Helpers.Services
{
    public class MailerService
    {
        private readonly IConfiguration _configuration;
        private string from;
        private string smtp;
        private int port;
        private string account;
        private string password;


        public MailerService(IConfiguration configuration)
        {
            _configuration = configuration;
            from = _configuration["Mailer:from"]!.ToString();
            smtp = _configuration["Mailer:smtp"]!.ToString();
            port = int.Parse(_configuration["Mailer:port"]!.ToString());
            account = _configuration["Mailer:account"]!.ToString();
            password = _configuration["Mailer:password"]!.ToString();
        }

        public async Task<string> SendAsync(string to, string subject, string body)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(MailboxAddress.Parse(_configuration["Mailer:from"]!.ToString()));
                mail.To.Add(MailboxAddress.Parse(to));
                mail.Subject = subject;
                mail.Body = new TextPart(TextFormat.Html) { Text = body };

                using var client = new SmtpClient();
                await client.ConnectAsync(smtp, port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(account, password);

                var result = await client.SendAsync(mail);
                await client.DisconnectAsync(true);
                return result;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}

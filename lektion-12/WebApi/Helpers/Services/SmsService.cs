using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System.Diagnostics;
using Twilio.Rest.Api.V2010.Account;
using Twilio;

namespace WebApi.Helpers.Services
{
    public class SmsService
    {
        private IConfiguration _configuration;
        private string from;
        private string account;
        private string token;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
            from = _configuration["SMS:from"]!.ToString();
            account = _configuration["SMS:account"]!.ToString();
            token = _configuration["SMS:token"]!.ToString();

            TwilioClient.Init(account, token);
        }

        public async Task<MessageResource> SendAsync(string to, string body)
        {
            try
            {
                MessageResource result = await MessageResource.CreateAsync(
                    to: new Twilio.Types.PhoneNumber(to), 
                    from: new Twilio.Types.PhoneNumber(from),
                    body: body);

                return result;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}

using Microsoft.Extensions.Options;
using System.Threading.Tasks;
// Twilio Begin
// using Twilio;
// using Twilio.Rest.Api.V2010.Account;
// using Twilio.Types;
// Twilio End

namespace Web2FA.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<SMSoptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public SMSoptions Options { get; }  // set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Twilio begin
            // // Plug in your SMS service here to send a text message.
            // // Your Account SID from twilio.com/console
            // var accountSid = Options.SMSAccountIdentification;
            // // Your Auth Token from twilio.com/console
            // var authToken = Options.SMSAccountPassword;
            // var 

            // TwilioClient.Init(accountSid, authToken);

            // var msg = MessageResource.Create(
            //   to: new PhoneNumber(number),
            //   from: new PhoneNumber(Options.SMSAccountFrom),
            //   body: message);
            // return Task.FromResult(0);
            // Twilio End

            // ASPSMS Begin
            // ASPSMS.SMS SMSSender = new ASPSMS.SMS();

            // SMSSender.Userkey = Options.SMSAccountIdentification;
            // SMSSender.Password = Options.SMSAccountPassword;
            // SMSSender.Originator = Options.SMSAccountFrom;

            // SMSSender.AddRecipient(number);
            // SMSSender.MessageData = message;

            // SMSSender.SendTextSMS();

            // return Task.FromResult(0);
            // ASPSMS End
        }
    }
}

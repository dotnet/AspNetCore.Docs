using Microsoft.Framework.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSMS.Services.Copy
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSMSSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSMSSenderOptions Options { get; }  // set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            var twilio = new Twilio.TwilioRestClient(
                Options.SID,           // Account Sid from dashboard
                Options.AuthToken);    // Auth Token

            var result = twilio.SendMessage(Options.SendNumber, number, message);
            // Use the debug output for testing without receiving a SMS message.
            // Remove the Debug.WriteLine(message) line after debugging.
            // System.Diagnostics.Debug.WriteLine(message);
            return Task.FromResult(0);
        }
    }
}

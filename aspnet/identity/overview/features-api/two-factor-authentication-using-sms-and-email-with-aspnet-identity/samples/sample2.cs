public class SmsService : IIdentityMessageService
{
    public Task SendAsync(IdentityMessage message)
    {
        // Twilio Begin
        // var Twilio = new TwilioRestClient(
        //   Keys.SMSAccountIdentification,
        //   Keys.SMSAccountPassword);
        // var result = Twilio.SendMessage(
        //   Keys.SMSAccountFrom,
        //   message.Destination, message.Body
        // );
        // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
        // Trace.TraceInformation(result.Status);
        // Twilio doesn't currently have an async API, so return success.
        // return Task.FromResult(0);
        // Twilio End

        // ASPSMS Begin 
        // var soapSms = new WebApplication1.ASPSMSX2.ASPSMSX2SoapClient("ASPSMSX2Soap");
        // soapSms.SendSimpleTextSMS(
        //   Keys.SMSAccountIdentification,
        //   Keys.SMSAccountPassword,
        //   message.Destination,
        //   Keys.SMSAccountFrom,
        //   message.Body);
        // soapSms.Close();
        // return Task.FromResult(0);
        // ASPSMS End
    }
}
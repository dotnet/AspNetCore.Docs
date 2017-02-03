public class SmsService : IIdentityMessageService
{
    public Task SendAsync(IdentityMessage message)
    {
        // Twilio Begin
        // var Twilio = new TwilioRestClient(
        //   System.Configuration.ConfigurationManager.AppSettings["SMSAccountIdentification"],
        //   System.Configuration.ConfigurationManager.AppSettings["SMSAccountPassword"]);
        // var result = Twilio.SendMessage(
        //   System.Configuration.ConfigurationManager.AppSettings["SMSAccountFrom"],
        //   message.Destination, message.Body
        // );
        // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
        // Trace.TraceInformation(result.Status);
        // Twilio doesn't currently have an async API, so return success.
        // return Task.FromResult(0);
        // Twilio End

        // ASPSMS Begin 
        // var soapSms = new MvcPWx.ASPSMSX2.ASPSMSX2SoapClient("ASPSMSX2Soap");
        // soapSms.SendSimpleTextSMS(
        //   System.Configuration.ConfigurationManager.AppSettings["SMSAccountIdentification"],
        //   System.Configuration.ConfigurationManager.AppSettings["SMSAccountPassword"],
        //   message.Destination,
        //   System.Configuration.ConfigurationManager.AppSettings["SMSAccountFrom"],
        //   message.Body);
        // soapSms.Close();
        // return Task.FromResult(0);
        // ASPSMS End
    }
}
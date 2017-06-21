public class SmsService : IIdentityMessageService
{
	public Task SendAsync(IdentityMessage message)
	{
		var Twilio = new TwilioRestClient(
		   ConfigurationManager.AppSettings["SMSSID"],
		   ConfigurationManager.AppSettings["SMSAuthToken"]
		);
		var result = Twilio.SendMessage(
			ConfigurationManager.AppSettings["SMSPhoneNumber"],
		   message.Destination, message.Body);

		// Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
		Trace.TraceInformation(result.Status);

		// Twilio doesn't currently have an async API, so return success.
		return Task.FromResult(0);
	}
}
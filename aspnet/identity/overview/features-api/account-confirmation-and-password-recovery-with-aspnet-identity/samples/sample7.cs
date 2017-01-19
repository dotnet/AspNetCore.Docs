public class EmailService : IIdentityMessageService
{
   public Task SendAsync(IdentityMessage message)
   {
      return configSendGridasync(message);
   }

   private Task configSendGridasync(IdentityMessage message)
   {
      var myMessage = new SendGridMessage();
      myMessage.AddTo(message.Destination);
      myMessage.From = new System.Net.Mail.MailAddress(
                          "Joe@contoso.com", "Joe S.");
      myMessage.Subject = message.Subject;
      myMessage.Text = message.Body;
      myMessage.Html = message.Body;

      var credentials = new NetworkCredential(
                 ConfigurationManager.AppSettings["mailAccount"],
                 ConfigurationManager.AppSettings["mailPassword"]
                 );

      // Create a Web transport for sending email.
      var transportWeb = new Web(credentials);

      // Send the email.
      if (transportWeb != null)
      {
         return transportWeb.DeliverAsync(myMessage);
      }
      else
      {
         return Task.FromResult(0);
      }
   }
}
void Application_Error(object sender, EventArgs e)
{
    // Get the error details
    HttpException lastErrorWrapper = Server.GetLastError() as HttpException;

    Exception lastError = lastErrorWrapper;
    if (lastErrorWrapper.InnerException != null)
        lastError = lastErrorWrapper.InnerException;

    string lastErrorTypeName = lastError.GetType().ToString();
    string lastErrorMessage = lastError.Message;
    string lastErrorStackTrace = lastError.StackTrace;

    const string ToAddress = "support@example.com";
    const string FromAddress = "support@example.com";
    const string Subject = "An Error Has Occurred!";
    
    // Create the MailMessage object
    MailMessage mm = new MailMessage(FromAddress, ToAddress);
    mm.Subject = Subject;
    mm.IsBodyHtml = true;
    mm.Priority = MailPriority.High;
    mm.Body = string.Format(@"
<html>
<body>
  <h1>An Error Has Occurred!</h1>
  <table cellpadding=""5"" cellspacing=""0"" border=""1"">
  <tr>
  <tdtext-align: right;font-weight: bold"">URL:</td>
  <td>{0}</td>
  </tr>
  <tr>
  <tdtext-align: right;font-weight: bold"">User:</td>
  <td>{1}</td>
  </tr>
  <tr>
  <tdtext-align: right;font-weight: bold"">Exception Type:</td>
  <td>{2}</td>
  </tr>
  <tr>
  <tdtext-align: right;font-weight: bold"">Message:</td>
  <td>{3}</td>
  </tr>
  <tr>
  <tdtext-align: right;font-weight: bold"">Stack Trace:</td>
  <td>{4}</td>
  </tr> 
  </table>
</body>
</html>",
        Request.RawUrl,
        User.Identity.Name,
        lastErrorTypeName,
        lastErrorMessage,
        lastErrorStackTrace.Replace(Environment.NewLine, "<br />"));

    // Attach the Yellow Screen of Death for this error   
    string YSODmarkup = lastErrorWrapper.GetHtmlErrorMessage();
    if (!string.IsNullOrEmpty(YSODmarkup))
    {
        Attachment YSOD = Attachment.CreateAttachmentFromString(YSODmarkup, "YSOD.htm");
        mm.Attachments.Add(YSOD);
    }

    // Send the email
    SmtpClient smtp = new SmtpClient();
    smtp.Send(mm);
}
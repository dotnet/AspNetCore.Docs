Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the error details
    Dim lastErrorWrapper As HttpException = CType(Server.GetLastError(), HttpException)
	
    Dim lastError As Exception = lastErrorWrapper
    If lastErrorWrapper.InnerException IsNot Nothing Then
        lastError = lastErrorWrapper.InnerException
    End If

    Dim lastErrorTypeName As String = lastError.GetType().ToString()
    Dim lastErrorMessage As String = lastError.Message
    Dim lastErrorStackTrace As String = lastError.StackTrace

    Const ToAddress As String = "support@example.com"
    Const FromAddress As String = "support@example.com"
    Const Subject As String = "An Error Has Occurred!"

    ' Create the MailMessage object
    Dim mm As New MailMessage(FromAddress, ToAddress)
    mm.Subject = Subject
    mm.IsBodyHtml = True
    mm.Priority = MailPriority.High
  mm.Body = string.Format( _
"<html>" & vbCrLf & _
"  <body>" & vbCrLf & _
"  <h1>An Error Has Occurred!</h1>" & vbCrLf & _
"  <table cellpadding=""5"" cellspacing=""0"" border=""1"">" & vbCrLf & _
"  <tr>" & vbCrLf & _
"  <tdtext-align: right;font-weight: bold"">URL:</td>" & vbCrLf & _
"  <td>{0}</td>" & vbCrLf & _
"  </tr>" & vbCrLf & _
"  <tr>" & vbCrLf & _
"  <tdtext-align: right;font-weight: bold"">User:</td>" & vbCrLf & _
"  <td>{1}</td>" & vbCrLf & _
"  </tr>" & vbCrLf & _
"  <tr>" & vbCrLf & _
"  <tdtext-align: right;font-weight: bold"">Exception Type:</td>" & vbCrLf & _
"  <td>{2}</td>" & vbCrLf & _
"  </tr>" & vbCrLf & _
"  <tr>" & vbCrLf & _
"  <tdtext-align: right;font-weight: bold"">Message:</td>" & vbCrLf & _
"  <td>{3}</td>" & vbCrLf & _
"  </tr>" & vbCrLf & _
"  <tr>" & vbCrLf & _
"  <tdtext-align: right;font-weight: bold"">Stack Trace:</td>" & vbCrLf & _
"  <td>{4}</td>" & vbCrLf & _
"  </tr> " & vbCrLf & _
"  </table>" & vbCrLf & _
"  </body>" & vbCrLf & _
"</html>", _
  Request.RawUrl, _
  User.Identity.Name, _
  lastErrorTypeName, _
  lastErrorMessage, _
  lastErrorStackTrace.Replace(Environment.NewLine, "<br />"))

    'Attach the Yellow Screen of Death for this error
    Dim YSODmarkup As String = lastErrorWrapper.GetHtmlErrorMessage()
    If Not String.IsNullOrEmpty(YSODmarkup) Then
        Dim YSOD As Attachment = Attachment.CreateAttachmentFromString(YSODmarkup, "YSOD.htm")
        mm.Attachments.Add(YSOD)
    End If

    ' Send the email
    Dim smtp As New SmtpClient()
    smtp.Send(mm)
End Sub
Protected Sub NewUserWizard_SendingMail(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MailMessageEventArgs) Handles NewUserWizard.SendingMail
     'Get the UserId of the just-added user
     Dim newUser As MembershipUser = Membership.GetUser(NewUserWizard.UserName)
     Dim newUserId As Guid = CType(newUser.ProviderUserKey, Guid)

     ' Determine the full verification URL (i.e., http://yoursite.com/Verification.aspx?ID=...)
     Dim urlBase As String = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath
     Dim verifyUrl As String = "/Verification.aspx?ID=" + newUserId.ToString()
     Dim fullUrl As String = urlBase & verifyUrl

     ' Replace <%VerificationUrl%> with the appropriate URL and querystring

     e.Message.Body = e.Message.Body.Replace("<%VerificationUrl%>", fullUrl)
End Sub
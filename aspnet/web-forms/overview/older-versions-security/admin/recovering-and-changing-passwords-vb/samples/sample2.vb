Protected Sub RecoverPwd_SendingMail(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MailMessageEventArgs)Handles RecoverPwd.SendingMail
 e.Message.CC.Add("webmaster@example.com")
End Sub
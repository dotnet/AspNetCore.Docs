protected void RecoverPwd_SendingMail(object sender, MailMessageEventArgs e)
{
	e.Message.CC.Add("webmaster@example.com");
}
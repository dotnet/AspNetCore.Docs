Response.Cookies.Add(authCookie)

Dim redirUrl As String = FormsAuthentication.GetRedirectUrl(UserName.Text, RememberMe.Checked)

Response.Redirect(redirUrl)
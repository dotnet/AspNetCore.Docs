Response.Cookies.Add(authCookie);

string redirUrl = FormsAuthentication.GetRedirectUrl(UserName.Text, RememberMe.Checked);

Response.Redirect(redirUrl);
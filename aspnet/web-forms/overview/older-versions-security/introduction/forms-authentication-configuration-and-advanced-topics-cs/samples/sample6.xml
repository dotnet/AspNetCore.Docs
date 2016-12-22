protected void LoginButton_Click(object sender, EventArgs e)

{

  // Three valid username/password pairs: Scott/password, Jisun/password, and Sam/password.

  string[] users = { "Scott", "Jisun", "Sam" };

  string[] passwords = { "password", "password", "password" };

  string[] companyName = { "Northwind Traders", "Adventure Works", "Contoso" };

  string[] titleAtCompany = { "Janitor", "Scientist", "Mascot" };

  for (int i = 0; i < users.Length; i++)

  {

  bool validUsername = (string.Compare(UserName.Text, users[i], true) == 0);

  bool validPassword = (string.Compare(Password.Text, passwords[i], false) == 0);

  if (validUsername && validPassword)

  {

  // Query the user store to get this user's User Data

  string userDataString = string.Concat(companyName[i], "|", titleAtCompany[i]);

  // Create the cookie that contains the forms authentication ticket

  HttpCookie authCookie = FormsAuthentication.GetAuthCookie(UserName.Text, RememberMe.Checked);

  // Get the FormsAuthenticationTicket out of the encrypted cookie

  FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

  // Create a new FormsAuthenticationTicket that includes our custom User Data

  FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

  // Update the authCookie's Value to use the encrypted version of newTicket

  authCookie.Value = FormsAuthentication.Encrypt(newTicket);

  // Manually add the authCookie to the Cookies collection

  Response.Cookies.Add(authCookie);

  // Determine redirect URL and send user there

  string redirUrl = FormsAuthentication.GetRedirectUrl(UserName.Text, RememberMe.Checked);

  Response.Redirect(redirUrl);

  }

  }

  // If we reach here, the user's credentials were invalid

  InvalidCredentialsMessage.Visible = true;

}
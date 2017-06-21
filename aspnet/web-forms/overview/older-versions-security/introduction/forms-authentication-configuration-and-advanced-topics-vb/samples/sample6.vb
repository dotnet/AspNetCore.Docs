Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click

 ' Three valid username/password pairs: Scott/password, Jisun/password, and Sam/password.

 Dim users() As String = {"Scott", "Jisun", "Sam"}

 Dim passwords() As String = {"password", "password", "password"}

 Dim companyName() As String = {"Northwind Traders", "Adventure Works", "Contoso"}

 Dim titleAtCompany() As String = {"Janitor", "Scientist", "Mascot"}

 For i As Integer = 0 To users.Length - 1

 Dim validUsername As Boolean = (String.Compare(UserName.Text, users(i), True) = 0)

 Dim validPassword As Boolean = (String.Compare(Password.Text, passwords(i), False) = 0)

 If validUsername AndAlso validPassword Then

 ' Query the user store to get this user's User Data

 Dim userDataString As String = String.Concat(companyName(i), "|", titleAtCompany(i))

 ' Create the cookie that contains the forms authentication ticket

 Dim authCookie As HttpCookie = FormsAuthentication.GetAuthCookie(UserName.Text, RememberMe.Checked)

 ' Get the FormsAuthenticationTicket out of the encrypted cookie

 Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)

 ' Create a new FormsAuthenticationTicket that includes our custom User Data

 Dim newTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString)

 ' Update the authCookie's Value to use the encrypted version of newTicket

 authCookie.Value = FormsAuthentication.Encrypt(newTicket)

 ' Manually add the authCookie to the Cookies collection

 Response.Cookies.Add(authCookie)

 ' Determine redirect URL and send user there

 Dim redirUrl As String = FormsAuthentication.GetRedirectUrl(UserName.Text, RememberMe.Checked)

 Response.Redirect(redirUrl)

 End If

 Next

 ' If we reach here, the user's credentials were invalid

 InvalidCredentialsMessage.Visible = True

End Sub
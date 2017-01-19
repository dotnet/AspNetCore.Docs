Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

 If Request.IsAuthenticated Then

 WelcomeBackMessage.Text = "Welcome back, " & User.Identity.Name & "!"

 ' Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage

 Dim ident As FormsIdentity = CType(User.Identity, FormsIdentity)

 If ident IsNot Nothing Then

 Dim ticket As FormsAuthenticationTicket = ident.Ticket

 Dim userDataString As String = ticket.UserData

 ' Split on the |

 Dim userDataPieces() As String = userDataString.Split("|".ToCharArray())

 Dim companyName As String = userDataPieces(0)

 Dim titleAtCompany As String = userDataPieces(1)

 WelcomeBackMessage.Text &= String.Format(" You are the {0} of {1}.", titleAtCompany, companyName)

 End If

 AuthenticatedMessagePanel.Visible = True

 AnonymousMessagePanel.Visible = False

 Else

 AuthenticatedMessagePanel.Visible = False

 AnonymousMessagePanel.Visible = True

 End If

End Sub
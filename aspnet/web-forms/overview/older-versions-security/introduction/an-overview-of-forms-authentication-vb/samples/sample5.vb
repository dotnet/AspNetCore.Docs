Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
 ' Three valid username/password pairs: Scott/password, Jisun/password, and Sam/password.
 Dim users() As String = {"Scott", "Jisun", "Sam"}
 Dim passwords() As String = {"password", "password", "password"}
 For i As Integer = 0 To users.Length - 1
 Dim validUsername As Boolean = (String.Compare(UserName.Text, users(i), True) = 0)
 Dim validPassword As Boolean = (String.Compare(Password.Text, passwords(i), False) = 0)
 If validUsername AndAlso validPassword Then
 ' TODO: Log in the user...
 ' TODO: Redirect them to the appropriate page
 End If
 Next
 ' If we reach here, the user's credentials were invalid
 InvalidCredentialsMessage.Visible = True
End Sub
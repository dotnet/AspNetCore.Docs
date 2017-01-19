Dim ident As CustomIdentity = CType(User.Identity, CustomIdentity)

If ident IsNot Nothing Then

 WelcomeBackMessage.Text &= String.Format(" You are the {0} of {1}.", ident.Title, ident.CompanyName)

End If
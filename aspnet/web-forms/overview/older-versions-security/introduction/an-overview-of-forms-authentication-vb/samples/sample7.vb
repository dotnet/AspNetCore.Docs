Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 If Request.IsAuthenticated Then
 WelcomeBackMessage.Text = "Welcome back!"
 AuthenticatedMessagePanel.Visible = True
 AnonymousMessagePanel.Visible = False
 Else
 AuthenticatedMessagePanel.Visible = False
 AnonymousMessagePanel.Visible = True
 End If
End Sub
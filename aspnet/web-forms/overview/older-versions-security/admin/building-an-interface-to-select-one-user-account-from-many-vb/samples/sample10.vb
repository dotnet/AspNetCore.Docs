Protected Sub FilteringUI_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles FilteringUI.ItemCommand
 If e.CommandName = "All" Then
 Me.UsernameToMatch = String.Empty
 Else
 Me.UsernameToMatch = e.CommandName
 End If

 BindUserAccounts()
End Sub
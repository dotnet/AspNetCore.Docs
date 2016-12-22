Protected Sub IsApproved_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles IsApproved.CheckedChanged
     'Toggle the user's approved status
     Dim userName As String = Request.QueryString("user")
     Dim usr As MembershipUser = Membership.GetUser(userName)
     usr.IsApproved = IsApproved.Checked
     Membership.UpdateUser(usr)

     StatusMessage.Text = "The user's approved status has been updated."

End Sub

Protected Sub UnlockUserButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnlockUserButton.Click
     'Unlock the user account
     Dim userName As String = Request.QueryString("user")
     Dim usr As MembershipUser = Membership.GetUser(userName)
     usr.UnlockUser()
     UnlockUserButton.Enabled = False

     StatusMessage.Text = "The user account has been unlocked."
End Sub
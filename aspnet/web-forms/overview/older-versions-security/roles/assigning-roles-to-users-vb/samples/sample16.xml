Protected Sub RolesUserList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles RolesUserList.RowDeleting 
     ' Get the selected role 
     Dim selectedRoleName As String = RoleList.SelectedValue 
 
     ' Reference the UserNameLabel 
     Dim UserNameLabel As Label = CType(RolesUserList.Rows(e.RowIndex).FindControl("UserNameLabel"),Label) 
 
     ' Remove the user from the role 
     Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName) 
 
     ' Refresh the GridView 
     DisplayUsersBelongingToRole() 
 
     ' Display a status message 
     ActionStatus.Text = String.Format("User {0} was removed from role {1}.", UserNameLabel.Text,selectedRoleName) 
End Sub
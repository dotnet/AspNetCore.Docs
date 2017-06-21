Protected Sub RolesUserList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles RolesUserList.RowDeleting 
     ... Code removed for brevity ... 
 
     ' Refresh the "by user" interface 
     CheckRolesForSelectedUser() 
End Sub 
 
Protected Sub AddUserToRoleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddUserToRoleButton.Click 
     ... Code removed for brevity ... 
 
     ' Refresh the "by user" interface 
     CheckRolesForSelectedUser() 
End Sub
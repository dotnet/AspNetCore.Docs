Protected Sub RoleList_RowDeleting(ByVal sender As Object,ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles RoleList.RowDeleting
 ' Get the RoleNameLabel
 Dim RoleNameLabel As Label = CType(RoleList.Rows(e.RowIndex).FindControl("RoleNameLabel"),Label)

 ' Delete the role
 Roles.DeleteRole(RoleNameLabel.Text,False)

 ' Rebind the data to the RoleList grid
 DisplayRolesInGrid()
End Sub
Protected Sub UserGrid_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles UserGrid.RowDeleting

     ' Determine the username of the user we are editing
     Dim UserName As String = UserGrid.DataKeys(e.RowIndex).Value.ToString()

     ' Delete the user
     Membership.DeleteUser(UserName)

     ' Revert the grid's EditIndex to -1 and rebind the data
     UserGrid.EditIndex = -1
     BindUserGrid()
End Sub
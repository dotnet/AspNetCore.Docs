Protected Sub UserGrid_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles UserGrid.RowEditing
     ' Set the grid's EditIndex and rebind the data

     UserGrid.EditIndex = e.NewEditIndex
     BindUserGrid()
End Sub

Protected Sub UserGrid_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles UserGrid.RowCancelingEdit
     ' Revert the grid's EditIndex to -1 and rebind the data
     UserGrid.EditIndex = -1
     BindUserGrid()
End Sub
    
Protected Sub UserGrid_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles UserGrid.RowUpdating
     ' Exit if the page is not valid
     If Not Page.IsValid Then
          Exit Sub
     End If

     ' Determine the username of the user we are editing
     Dim UserName As String = UserGrid.DataKeys(e.RowIndex).Value.ToString()

     ' Read in the entered information and update the user
     Dim EmailTextBox As TextBox = CType(UserGrid.Rows(e.RowIndex).FindControl("Email"),TextBox)
     Dim CommentTextBox As TextBox= CType(UserGrid.Rows(e.RowIndex).FindControl("Comment"),TextBox)

     ' Return information about the user
     Dim UserInfo As MembershipUser = Membership.GetUser(UserName)

     ' Update the User account information
     UserInfo.Email = EmailTextBox.Text.Trim()
     UserInfo.Comment = CommentTextBox.Text.Trim()

     Membership.UpdateUser(UserInfo)

     ' Revert the grid's EditIndex to -1 and rebind the data
     UserGrid.EditIndex = -1
     BindUserGrid()
End Sub
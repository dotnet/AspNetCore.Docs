Protected Sub UserGrid_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles UserGrid.RowCreated
     If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowIndex <> UserGrid.EditIndex Then
          ' Programmatically reference the Edit and Delete LinkButtons
          Dim EditButton As LinkButton = CType(e.Row.FindControl("EditButton"), LinkButton)

          Dim DeleteButton As LinkButton = CType(e.Row.FindControl("DeleteButton"), LinkButton)

          EditButton.Visible = (User.IsInRole("Administrators") OrElse User.IsInRole("Supervisors"))
          DeleteButton.Visible = User.IsInRole("Administrators")
     End If
End Sub
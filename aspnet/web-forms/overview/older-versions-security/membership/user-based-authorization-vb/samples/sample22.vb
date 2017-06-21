<PrincipalPermission(SecurityAction.Demand, Authenticated:=True)> _
Protected Sub FilesGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FilesGrid.SelectedIndexChanged
 ...
End Sub

<PrincipalPermission(SecurityAction.Demand, Name:="Tito")> _
Protected Sub FilesGrid_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles FilesGrid.RowDeleting
 ...
End Sub
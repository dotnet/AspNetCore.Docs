Protected Sub CreateRoleButton_Click(ByVal sender As Object,ByVal e As System.EventArgs) Handles CreateRoleButton.Click
 Dim newRoleName As String = RoleName.Text.Trim()

 If Not Roles.RoleExists(newRoleName) Then
 ' Create the role
 Roles.CreateRole(newRoleName)

 ' Refresh the RoleList Grid
 DisplayRolesInGrid()
 End If

 RoleName.Text = String.Empty 
End Sub
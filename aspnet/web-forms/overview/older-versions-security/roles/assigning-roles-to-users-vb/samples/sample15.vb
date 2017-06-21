Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 
     If Not Page.IsPostBack Then 
          ' Bind the users and roles 
          BindUsersToUserList() 
          BindRolesToList() 
 
          ' Check the selected user's roles 
          CheckRolesForSelectedUser() 
 
          'Display those users belonging to the currently selected role 
          DisplayUsersBelongingToRole() 
     End If 
End Sub 
 
... 
 
Protected Sub RoleList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoleList.SelectedIndexChanged 
     DisplayUsersBelongingToRole() 
End Sub
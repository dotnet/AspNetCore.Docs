Protected Sub Page_Load(ByVal sender As Object,ByVal e As System.EventArgs) Handles Me.Load 
     If Not Page.IsPostBack Then 
          ' Bind the users and roles 
          BindUsersToUserList() 
          BindRolesToList() 
          ' Check the selected user's roles 
          CheckRolesForSelectedUser() 
     End If 
End Sub 
 
... 
 
Protected Sub UserList_SelectedIndexChanged(ByVal sender As Object,ByVal e As System.EventArgs) Handles UserList.SelectedIndexChanged 
     CheckRolesForSelectedUser() 
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 
     If Not Page.IsPostBack Then 
          ' Reference the SpecifyRolesStep WizardStep 
          Dim SpecifyRolesStep As WizardStep = CType(RegisterUserWithRoles.FindControl("SpecifyRolesStep"),WizardStep) 
 
          ' Reference the RoleList CheckBoxList 
          Dim RoleList As CheckBoxList = CType(SpecifyRolesStep.FindControl("RoleList"), CheckBoxList) 
 
          ' Bind the set of roles to RoleList 
          RoleList.DataSource = Roles.GetAllRoles() 
          RoleList.DataBind() 
     End If 
End Sub
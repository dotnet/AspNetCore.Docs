protected void Page_Load(object sender, EventArgs e) 
{ 
     if (!Page.IsPostBack) 
     { 
          // Reference the SpecifyRolesStep WizardStep 
          WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep; 

          // Reference the RoleList CheckBoxList 
          CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList; 

          // Bind the set of roles to RoleList 
          RoleList.DataSource = Roles.GetAllRoles(); 
          RoleList.DataBind(); 
     } 
}
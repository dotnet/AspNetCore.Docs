protected void RegisterUserWithRoles_ActiveStepChanged(object sender, EventArgs e) 
{ 
     // Have we JUST reached the Complete step? 
     if (RegisterUserWithRoles.ActiveStep.Title == "Complete") 
     { 
          // Reference the SpecifyRolesStep WizardStep 
          WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep; 

          // Reference the RoleList CheckBoxList 
          CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList; 

          // Add the checked roles to the just-added user 
          foreach (ListItem li in RoleList.Items) 

          { 
               if (li.Selected) 
                    Roles.AddUserToRole(RegisterUserWithRoles.UserName, li.Text); 
          } 
     } 
}
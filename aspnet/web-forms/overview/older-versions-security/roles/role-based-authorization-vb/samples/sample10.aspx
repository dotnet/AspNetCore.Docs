<asp:LoginView ID="LoginView1" runat="server">
     <RoleGroups>
          <asp:RoleGroup Roles="Administrators">

               <ContentTemplate>
                    As an Administrator, you may edit and delete user accounts. 
                    Remember: With great power comes great responsibility!
               </ContentTemplate>
          </asp:RoleGroup>
          <asp:RoleGroup Roles="Supervisors">
               <ContentTemplate>
                    As a Supervisor, you may edit users&#39; Email and Comment information. 
                    Simply click the Edit button, make your changes, and then click Update.
               </ContentTemplate>

          </asp:RoleGroup>
     </RoleGroups>
     <LoggedInTemplate>
          You are not a member of the Supervisors or Administrators roles. 
          Therefore you cannot edit or delete any user information.
     </LoggedInTemplate>
     </AnonymousTemplate>
          You are not logged into the system. 
          Therefore you cannot edit or delete any user information.
     </AnonymousTemplate>
</asp:LoginView>
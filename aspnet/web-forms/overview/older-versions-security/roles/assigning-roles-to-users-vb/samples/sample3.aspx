<asp:Repeater ID="UsersRoleList" runat="server"> 
     <ItemTemplate> 
          <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" 
               Text='<%# Container.DataItem %>' /> 
          <br /> 
     </ItemTemplate> 
</asp:Repeater>
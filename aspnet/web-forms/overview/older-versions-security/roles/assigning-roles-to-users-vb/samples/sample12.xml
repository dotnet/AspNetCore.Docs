<h3>Manage Users By Role</h3> 
<p> 
     <b>Select a Role:</b> 
     <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true"></asp:DropDownList> 
</p> 
<p> 
     <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="false" 
          EmptyDataText="No users belong to this role."> 
          <Columns> 
               <asp:TemplateField HeaderText="Users"> 
                    <ItemTemplate> 
                         <asp:Label runat="server" id="UserNameLabel" 
                              Text='<%# Container.DataItem %>'></asp:Label> 
                    </ItemTemplate> 
               </asp:TemplateField> 
          </Columns> 
     </asp:GridView> 
</p>
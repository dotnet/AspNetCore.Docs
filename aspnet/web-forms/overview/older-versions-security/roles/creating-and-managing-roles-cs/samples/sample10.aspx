<asp:GridView ID="RoleList" runat="server" AutoGenerateColumns="false">    
 <Columns>    
 <asp:TemplateField HeaderText="Role">    
 <ItemTemplate>    
 <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' />    
 </ItemTemplate>    
 </asp:TemplateField>    
 </Columns>    
</asp:GridView>
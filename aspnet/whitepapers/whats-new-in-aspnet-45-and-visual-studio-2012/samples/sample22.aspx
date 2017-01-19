<asp:GridView ID="categoriesGrid"
runat="server"
ItemType="WebApplication1.Model.Category"
SelectMethod="GetCategories" AutoGenerateColumns="false">
<Columns>
 	   <asp:BoundField DataField="CategoryID" HeaderText="ID" />
 	   <asp:BoundField DataField="CategoryName" HeaderText="Name" />
 	   <asp:BoundField DataField="Description" HeaderText="Description" />
 	   <asp:TemplateField HeaderText="# of Products">
 		   <ItemTemplate><%# Item.Products.Count %></ItemTemplate>
 	   </asp:TemplateField>
</Columns>
</asp:GridView>
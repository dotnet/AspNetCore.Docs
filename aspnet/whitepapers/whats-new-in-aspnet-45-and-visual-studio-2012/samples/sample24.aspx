<asp:GridView ID="categoriesGrid"
runat="server"
AutoGenerateColumns="false"
AllowSorting="true" AllowPaging="true" PageSize="5"
ItemType="WebApplication1.Model.Category" DataKeyNames="CategoryID"
SelectMethod="GetCategories"
UpdateMethod="UpdateCategory">
<Columns>
 	   <asp:BoundField DataField="CategoryID" HeaderText="ID" SortExpression="CategoryID" />
 	   <asp:BoundField DataField="CategoryName" HeaderText="Name" SortExpression="CategoryName" />
 	   <asp:BoundField DataField="Description" HeaderText="Description" />
 	   <asp:TemplateField HeaderText="# of Products">
 		   <ItemTemplate><%# Item.Products.Count %></ItemTemplate>
 	   </asp:TemplateField>
</Columns>
<EmptyDataTemplate>No categories found with a product count of 
 	  <%# minProductsCount.SelectedValue %></EmptyDataTemplate>
</asp:GridView>
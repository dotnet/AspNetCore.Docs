<asp:GridView ID="categoriesGrid" runat="server"
    AutoGenerateColumns="false"
    ItemType="WebFormsLab.Model.Category" DataKeyNames="CategoryId"
    SelectMethod="GetCategories">
  <Columns>
    <asp:BoundField DataField="CategoryId" HeaderText="ID" />
    <asp:BoundField DataField="CategoryName" HeaderText="Name" />
    <asp:BoundField DataField="Description" HeaderText="Description" />
    <asp:TemplateField HeaderText="# of Products">
      <ItemTemplate><%#: Item.Products.Count %></ItemTemplate>
    </asp:TemplateField>
  </Columns>
  <EmptyDataTemplate>
      No categories found with a product count of <%#: minProductsCount.SelectedValue %>
  </EmptyDataTemplate>
</asp:GridView>
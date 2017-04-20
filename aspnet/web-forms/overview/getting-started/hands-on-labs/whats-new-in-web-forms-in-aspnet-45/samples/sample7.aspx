<asp:GridView ID="categoriesGrid" runat="server"
    AutoGenerateColumns="false"
    ItemType="WebFormsLab.Model.Category" DataKeyNames="CategoryId"
    SelectMethod="GetCategories">
  <Columns>
    <asp:BoundField DataField="CategoryId" HeaderText="ID" SortExpression="CategoryId" />
    <asp:BoundField DataField="CategoryName" HeaderText="Name" SortExpression="CategoryName" />
    <asp:BoundField DataField="Description" HeaderText="Description" />
    <asp:TemplateField HeaderText="# of Products">
      <ItemTemplate><%#: Item.Products.Count %></ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
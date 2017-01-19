<h3>Products</h3>
<asp:GridView ID="productsGrid" runat="server" 
  CellPadding="4"
  AutoGenerateColumns="false"
  ItemType="WebFormsLab.Model.Product"
  DataKeyNames="ProductId"
  SelectMethod="GetProducts">
  <Columns>
    <asp:TemplateField>
      <ItemTemplate>
        <a href="ProductDetails.aspx?productId=<%#: Item.ProductId %>">View</a>
      </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="ProductId" HeaderText="ID" />
    <asp:BoundField DataField="ProductName" HeaderText="Name" />
    <asp:BoundField DataField="Description" HeaderText="Description" HtmlEncode="false" />
    <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
  </Columns>
  <EmptyDataTemplate>
    Select a category above to see its products
  </EmptyDataTemplate>
</asp:GridView>
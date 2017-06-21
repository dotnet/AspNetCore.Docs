<asp:DetailsView ID="ProductDetails" runat="server"
    AutoGenerateRows="False" DataKeyNames="ProductID"
    DataSourceID="ObjectDataSource1" EnableViewState="False">
    <Fields>
        <asp:BoundField DataField="ProductName"
          HeaderText="Product" SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName"
          HeaderText="Category" ReadOnly="True"
          SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName"
          HeaderText="Supplier" ReadOnly="True"
          SortExpression="SupplierName" />
        <asp:BoundField DataField="QuantityPerUnit"
          HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
        <asp:BoundField DataField="UnitPrice"
          DataFormatString="{0:c}" HeaderText="Price"
          HtmlEncode="False" SortExpression="UnitPrice" />
        <asp:BoundField DataField="UnitsInStock"
          HeaderText="UnitsInStock" SortExpression="Units In Stock" />
        <asp:BoundField DataField="UnitsOnOrder"
          HeaderText="UnitsOnOrder" SortExpression="Units On Order" />
        <asp:BoundField DataField="ReorderLevel"
          HeaderText="ReorderLevel" SortExpression="Reorder Level" />
        <asp:CheckBoxField DataField="Discontinued"
          HeaderText="Discontinued" SortExpression="Discontinued" />
    </Fields>
</asp:DetailsView>
<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" AllowPaging="True"
    EnableViewState="False">
    <Fields>
        <asp:BoundField DataField="ProductName" HeaderText="Product"
          SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category"
          ReadOnly="True" SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName" HeaderText="Supplier"
          ReadOnly="True" SortExpression="SupplierName" />
        <asp:BoundField DataField="QuantityPerUnit"
          HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Price"
          SortExpression="UnitPrice" />
        <asp:BoundField DataField="UnitsInStock"
          HeaderText="Units In Stock" SortExpression="UnitsInStock" />
        <asp:BoundField DataField="UnitsOnOrder"
          HeaderText="Units On Order" SortExpression="UnitsOnOrder" />
        <asp:CheckBoxField DataField="Discontinued"
          HeaderText="Discontinued" SortExpression="Discontinued" />
    </Fields>
</asp:DetailsView>
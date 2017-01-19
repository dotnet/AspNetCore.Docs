<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" />
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True"
            SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True"
            SortExpression="SupplierName" />
    </Columns>
</asp:GridView>
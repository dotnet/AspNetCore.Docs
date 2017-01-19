<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:BoundField DataField="ProductName"
           HeaderText="ProductName" SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category"
           ReadOnly="True"
           SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName" HeaderText="Supplier"
           ReadOnly="True"
           SortExpression="SupplierName" />
        <asp:CheckBoxField DataField="Discontinued"
           HeaderText="Discontinued" SortExpression="Discontinued" />
    </Columns>
</asp:GridView>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID"
            InsertVisible="False"
            ReadOnly="True" SortExpression="ProductID" />
        <asp:BoundField DataField="ProductName" HeaderText="ProductName"
            SortExpression="ProductName" />
        <asp:BoundField DataField="SupplierID" HeaderText="SupplierID"
           SortExpression="SupplierID" />
        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID"
           SortExpression="CategoryID" />
        <asp:BoundField DataField="QuantityPerUnit"
           HeaderText="QuantityPerUnit"
           SortExpression="QuantityPerUnit" />
        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"
           SortExpression="UnitPrice" />
        <asp:BoundField DataField="UnitsInStock"
           HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
        <asp:BoundField DataField="UnitsOnOrder"
           HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
        <asp:BoundField DataField="ReorderLevel"
           HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
        <asp:CheckBoxField DataField="Discontinued"
           HeaderText="Discontinued" SortExpression="Discontinued" />
        <asp:BoundField DataField="CategoryName"
           HeaderText="CategoryName" ReadOnly="True"
            SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName"
            HeaderText="SupplierName" ReadOnly="True"
            SortExpression="SupplierName" />
    </Columns>
</asp:GridView>
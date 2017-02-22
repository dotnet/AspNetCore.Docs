<asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID"
    DataSourceID="ObjectDataSource1" EnableViewState="False">
    <ItemTemplate>
        ProductID:       <asp:Label ID="ProductIDLabel" runat="server"
                            Text='<%# Eval("ProductID") %>' /><br />
        ProductName:     <asp:Label ID="ProductNameLabel" runat="server"
                            Text='<%# Eval("ProductName") %>' /><br />
        SupplierID:      <asp:Label ID="SupplierIDLabel" runat="server"
                            Text='<%# Eval("SupplierID") %>' /><br />
        CategoryID:      <asp:Label ID="CategoryIDLabel" runat="server"
                            Text='<%# Eval("CategoryID") %>'/><br />
        QuantityPerUnit: <asp:Label ID="QuantityPerUnitLabel" runat="server"
                            Text='<%# Eval("QuantityPerUnit") %>' /><br />
        UnitPrice:       <asp:Label ID="UnitPriceLabel" runat="server"
                            Text='<%# Eval("UnitPrice") %>' /><br />
        UnitsInStock:    <asp:Label ID="UnitsInStockLabel" runat="server"
                            Text='<%# Eval("UnitsInStock") %>' /><br />
        UnitsOnOrder:    <asp:Label ID="UnitsOnOrderLabel" runat="server"
                            Text='<%# Eval("UnitsOnOrder") %>' /><br />
        ReorderLevel:    <asp:Label ID="ReorderLevelLabel" runat="server"
                            Text='<%# Eval("ReorderLevel") %>' /><br />
        Discontinued:    <asp:Label ID="DiscontinuedLabel" runat="server"
                            Text='<%# Eval("Discontinued") %>' /><br />
        CategoryName:    <asp:Label ID="CategoryNameLabel" runat="server"
                            Text='<%# Eval("CategoryName") %>' /><br />
        SupplierName:    <asp:Label ID="SupplierNameLabel" runat="server"
                            Text='<%# Eval("SupplierName") %>' /><br />
        <br />
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProducts" TypeName="ProductsBLL">
</asp:ObjectDataSource>
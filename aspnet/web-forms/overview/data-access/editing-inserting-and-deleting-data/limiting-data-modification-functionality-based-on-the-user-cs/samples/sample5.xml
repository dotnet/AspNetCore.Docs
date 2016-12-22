<asp:GridView ID="ProductsBySupplier" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ProductsBySupplierDataSource">
    <Columns>
        <asp:CommandField ShowEditButton="True" />
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit"
            SortExpression="QuantityPerUnit" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            ReadOnly="True" SortExpression="Discontinued" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ProductsBySupplierDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}" TypeName="ProductsBLL"
    SelectMethod="GetProductsBySupplierID" UpdateMethod="UpdateProduct">
    <UpdateParameters>
        <asp:Parameter Name="productName" Type="String" />
        <asp:Parameter Name="quantityPerUnit" Type="String" />
        <asp:Parameter Name="productID" Type="Int32" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="SupplierDetails" Name="supplierID"
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:GridView ID="SuppliersProducts" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="SuppliersProductsDataSource"
    EnableViewState="False" runat="server">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Price"
            SortExpression="UnitPrice" DataFormatString="{0:C}"
            HtmlEncode="False" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            SortExpression="Discontinued" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="SuppliersProductsDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProductsBySupplierID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:ControlParameter ControlID="Suppliers" Name="supplierID"
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
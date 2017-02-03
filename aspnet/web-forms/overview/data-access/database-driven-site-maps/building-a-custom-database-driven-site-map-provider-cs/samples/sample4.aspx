<asp:DetailsView ID="ProductInfo" runat="server" AutoGenerateRows="False" 
    DataKeyNames="ProductID" DataSourceID="ProductDataSource" 
    EnableViewState="False">
    <Fields>
        <asp:BoundField DataField="ProductName" HeaderText="Product" 
            SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            ReadOnly="True" SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName" HeaderText="Supplier" 
            ReadOnly="True" SortExpression="SupplierName" />
        <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" 
            SortExpression="QuantityPerUnit" />
        <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" 
            HeaderText="Price" HtmlEncode="False" 
            SortExpression="UnitPrice" />
        <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" 
            SortExpression="UnitsInStock" />
        <asp:BoundField DataField="UnitsOnOrder" HeaderText="Units On Order" 
            SortExpression="UnitsOnOrder" />
        <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" 
            SortExpression="ReorderLevel" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" 
            SortExpression="Discontinued" />
    </Fields>
</asp:DetailsView>
<asp:ObjectDataSource ID="ProductDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProductByProductID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="productID" 
            QueryStringField="ProductID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
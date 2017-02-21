<asp:GridView ID="Products" runat="server" AllowSorting="True"
    AutoGenerateColumns="False" DataKeyNames="ProductID" 
    DataSourceID="ProductsDataSource">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product" 
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" 
            HeaderText="Price" HtmlEncode="False" 
            SortExpression="UnitPrice">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="PriceQuartile" HeaderText="Price Quartile" 
            SortExpression="PriceQuartile">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProductsWithPriceQuartile" 
    TypeName="ProductsBLLWithSprocs">
</asp:ObjectDataSource>
<asp:GridView ID="ProductsByCategory" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ProductsByCategoryDataSource" 
    EnableViewState="False">
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="ProductID" 
            DataNavigateUrlFormatString=
                "~/SiteMapProvider/ProductDetails.aspx?ProductID={0}"
            Text="View Details" />
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" 
            HeaderText="Price" HtmlEncode="False" 
            SortExpression="UnitPrice" />
        <asp:BoundField DataField="SupplierName" HeaderText="Supplier" 
            ReadOnly="True" SortExpression="SupplierName" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ProductsByCategoryDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="categoryID" 
            QueryStringField="CategoryID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
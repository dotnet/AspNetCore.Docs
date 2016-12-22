<asp:GridView ID="Categories" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="CategoryID" DataSourceID="CategoriesDataSource" 
    EnableViewState="False">
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="CategoryID" 
            DataNavigateUrlFormatString=
                "~/SiteMapProvider/ProductsByCategory.aspx?CategoryID={0}"
            Text="View Products" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            SortExpression="CategoryName" />
        <asp:BoundField DataField="Description" HeaderText="Description" 
            SortExpression="Description" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" 
    TypeName="CategoriesBLL"></asp:ObjectDataSource>
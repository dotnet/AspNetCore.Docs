<asp:GridView ID="Categories" runat="server" 
    AutoGenerateColumns="False" DataKeyNames="CategoryID"
    DataSourceID="CategoriesDataSource" EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            SortExpression="CategoryName" />
        <asp:BoundField DataField="Description" HeaderText="Description" 
            SortExpression="Description" />
        <asp:BoundField DataField="BrochurePath" HeaderText="Brochure" 
            SortExpression="BrochurePath" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategories" TypeName="CategoriesBLL">
</asp:ObjectDataSource>
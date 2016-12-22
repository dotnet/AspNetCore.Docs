<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ProductsWithCategoryInfoDataSource"
    EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID"
            InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
        <asp:BoundField DataField="ProductName" HeaderText="ProductName"
            SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName"
            SortExpression="CategoryName" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="ProductsWithCategoryInfoDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    SelectCommand="
        SELECT Products.ProductID, Products.ProductName, Categories.CategoryName
        FROM Categories
        INNER JOIN Products ON Categories.CategoryID = Products.CategoryID">
</asp:SqlDataSource>
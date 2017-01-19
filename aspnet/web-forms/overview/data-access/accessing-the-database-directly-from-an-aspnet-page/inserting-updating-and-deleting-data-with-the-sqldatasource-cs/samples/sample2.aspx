<asp:SqlDataSource ID="ProductsDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    SelectCommand=
        "SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]"
    DeleteCommand="DELETE FROM Products WHERE ProductID = @ProductID">
    <DeleteParameters>
        <asp:Parameter Name="ProductID" />
    </DeleteParameters>
</asp:SqlDataSource>
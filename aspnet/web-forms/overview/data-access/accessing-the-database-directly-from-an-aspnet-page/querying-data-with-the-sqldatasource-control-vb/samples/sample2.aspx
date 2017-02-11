<asp:SqlDataSource ID="ProductsDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]">
</asp:SqlDataSource>
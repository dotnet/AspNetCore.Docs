<asp:SqlDataSource ID="Products25BucksAndUnderDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    SelectCommand=
        "SELECT [ProductID], [ProductName], [UnitPrice]
        FROM [Products] WHERE ([UnitPrice] <= @UnitPrice)">
    <SelectParameters>
        <asp:Parameter DefaultValue="25.00" Name="UnitPrice" Type="Decimal" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:DetailsView ID="ManageProducts" runat="server" AllowPaging="True"
    AutoGenerateRows="False" DataKeyNames="ProductID"
    DataSourceID="ManageProductsDataSource" EnableViewState="False">
    <Fields>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID"
            InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
        <asp:BoundField DataField="ProductName" HeaderText="ProductName"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"
            SortExpression="UnitPrice" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            SortExpression="Discontinued" />
    </Fields>
</asp:DetailsView>
<asp:SqlDataSource ID="ManageProductsDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    DeleteCommand=
        "DELETE FROM [Products] WHERE [ProductID] = @ProductID"
    InsertCommand=
        "INSERT INTO [Products] ([ProductName], [UnitPrice], [Discontinued])
         VALUES (@ProductName, @UnitPrice, @Discontinued)"
    SelectCommand=
        "SELECT [ProductID], [ProductName], [UnitPrice], [Discontinued]
         FROM [Products]"
    UpdateCommand=
        "UPDATE [Products] SET [ProductName] = @ProductName,
         [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued
         WHERE [ProductID] = @ProductID">
    <DeleteParameters>
        <asp:Parameter Name="ProductID" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProductName" Type="String" />
        <asp:Parameter Name="UnitPrice" Type="Decimal" />
        <asp:Parameter Name="Discontinued" Type="Boolean" />
        <asp:Parameter Name="ProductID" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="ProductName" Type="String" />
        <asp:Parameter Name="UnitPrice" Type="Decimal" />
        <asp:Parameter Name="Discontinued" Type="Boolean" />
    </InsertParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="ProductsDataSourceWithOptimisticConcurrency"
    runat="server" ConflictDetection="CompareAllValues"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    DeleteCommand=
        "DELETE FROM [Products]
         WHERE [ProductID] = @original_ProductID
         AND [ProductName] = @original_ProductName
         AND (([UnitPrice] IS NULL AND @original_UnitPrice IS NULL)
              OR ([UnitPrice] = @original_UnitPrice))
         AND [Discontinued] = @original_Discontinued"
    OldValuesParameterFormatString=
        "original_{0}"
    SelectCommand=
        "SELECT [ProductID], [ProductName], [UnitPrice], [Discontinued]
         FROM [Products]"
    UpdateCommand=
        "UPDATE [Products]
         SET [ProductName] = @ProductName, [UnitPrice] = @UnitPrice,
            [Discontinued] = @Discontinued
         WHERE [ProductID] = @original_ProductID
         AND [ProductName] = @original_ProductName
         AND (([UnitPrice] IS NULL AND @original_UnitPrice IS NULL)
            OR ([UnitPrice] = @original_UnitPrice))
        AND [Discontinued] = @original_Discontinued">
    <DeleteParameters>
        <asp:Parameter Name="original_ProductID" Type="Int32" />
        <asp:Parameter Name="original_ProductName" Type="String" />
        <asp:Parameter Name="original_UnitPrice" Type="Decimal" />
        <asp:Parameter Name="original_Discontinued" Type="Boolean" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProductName" Type="String" />
        <asp:Parameter Name="UnitPrice" Type="Decimal" />
        <asp:Parameter Name="Discontinued" Type="Boolean" />
        <asp:Parameter Name="original_ProductID" Type="Int32" />
        <asp:Parameter Name="original_ProductName" Type="String" />
        <asp:Parameter Name="original_UnitPrice" Type="Decimal" />
        <asp:Parameter Name="original_Discontinued" Type="Boolean" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:GridView ID="Products" runat="server"
    AutoGenerateColumns="False" DataKeyNames="ProductID"
    DataSourceID="ProductsDataSourceWithOptimisticConcurrency">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Price"
            SortExpression="UnitPrice" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            SortExpression="Discontinued" />
    </Columns>
</asp:GridView>
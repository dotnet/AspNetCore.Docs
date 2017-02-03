<asp:SqlDataSource ID="ProductsDataSourceWithOptimisticConcurrency"
    runat="server" ...>
    <DeleteParameters>
        <asp:Parameter Name="original_ProductID" Type="Int32" />
        <asp:Parameter Name="original_ProductName" Type="String" />
        <asp:Parameter Name="original_UnitPrice" Type="Decimal" />
        <asp:Parameter Name="original_Discontinued" Type="Boolean" />
    </DeleteParameters>
    <UpdateParameters>
        ...
    </UpdateParameters>
    ...
</asp:SqlDataSource>
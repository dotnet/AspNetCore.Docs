<asp:ObjectDataSource ID="ProductsDefaultPagingDataSource"
    OldValuesParameterFormatString="original_{0}" TypeName="ProductsBLL"
    SelectMethod="GetProductsSortedAsPagedDataSource"
    OnSelected="ProductsDefaultPagingDataSource_Selected" runat="server">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="ProductName"
            Name="sortExpression" QueryStringField="sortExpression"
            Type="String" />
        <asp:QueryStringParameter DefaultValue="0" Name="pageIndex"
            QueryStringField="pageIndex" Type="Int32" />
        <asp:QueryStringParameter DefaultValue="4" Name="pageSize"
            QueryStringField="pageSize" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
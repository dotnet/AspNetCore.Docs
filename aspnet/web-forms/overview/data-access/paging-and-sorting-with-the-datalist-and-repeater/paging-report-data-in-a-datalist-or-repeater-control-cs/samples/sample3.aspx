<asp:DataList ID="ProductsDefaultPaging" runat="server" Width="100%"
    DataKeyField="ProductID" DataSourceID="ProductsDefaultPagingDataSource"
    RepeatColumns="2" EnableViewState="False">
    <ItemTemplate>
        <h4><asp:Label ID="ProductNameLabel" runat="server"
            Text='<%# Eval("ProductName") %>'></asp:Label></h4>
        Category:
        <asp:Label ID="CategoryNameLabel" runat="server"
            Text='<%# Eval("CategoryName") %>'></asp:Label><br />
        Supplier:
        <asp:Label ID="SupplierNameLabel" runat="server"
            Text='<%# Eval("SupplierName") %>'></asp:Label><br />
        <br />
        <br />
    </ItemTemplate>
    <ItemStyle Width="50%" />
</asp:DataList>
<asp:ObjectDataSource ID="ProductsDefaultPagingDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}" TypeName="ProductsBLL"
    SelectMethod="GetProductsAsPagedDataSource">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="0" Name="pageIndex"
             QueryStringField="pageIndex" Type="Int32" />
        <asp:QueryStringParameter DefaultValue="4" Name="pageSize"
             QueryStringField="pageSize" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
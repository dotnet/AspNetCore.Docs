<asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID"
    DataSourceID="ObjectDataSource1" EnableViewState="False">
    <ItemTemplate>
        <h4>
            <asp:Label runat="server" ID="ProductNameLabel"
                Text='<%# Eval("ProductName") %>'></asp:Label>
        </h4>
        Available in the
            <asp:Label runat="server" ID="CategoryNameLabel"
                Text='<%# Eval("CategoryName") %>' />
        store for
            <asp:Label runat="server" ID="UnitPriceLabel"
                Text='<%# Eval("UnitPrice", "{0:C}") %>' />
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProducts" TypeName="ProductsBLL">
</asp:ObjectDataSource>
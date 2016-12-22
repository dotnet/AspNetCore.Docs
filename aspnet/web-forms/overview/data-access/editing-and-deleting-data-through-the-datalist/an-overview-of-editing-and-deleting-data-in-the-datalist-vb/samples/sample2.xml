<asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID"
    DataSourceID="ObjectDataSource1" RepeatColumns="2">
    <ItemTemplate>
        <h5>
            <asp:Label runat="server" ID="ProductNameLabel"
                Text='<%# Eval("ProductName") %>'></asp:Label>
        </h5>
        Price: <asp:Label runat="server" ID="Label1"
                    Text='<%# Eval("UnitPrice", "{0:C}") %>' />
        <br />
        <br />
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    SelectMethod="GetProducts" TypeName="ProductsBLL"
    OldValuesParameterFormatString="original_{0}">
</asp:ObjectDataSource>
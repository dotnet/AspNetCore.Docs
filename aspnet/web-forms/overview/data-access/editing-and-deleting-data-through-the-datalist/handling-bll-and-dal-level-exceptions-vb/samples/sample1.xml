<asp:DataList ID="Products" runat="server" DataKeyField="ProductID"
    DataSourceID="ProductsDataSource" RepeatColumns="2">
    <ItemTemplate>
        <h5>
            <asp:Label runat="server" ID="ProductNameLabel"
                Text='<%# Eval("ProductName") %>' />
        </h5>
        Price:
            <asp:Label runat="server" ID="Label1"
                Text='<%# Eval("UnitPrice", "{0:C}") %>' />
        <br />
            <asp:Button runat="server" id="EditProduct" CommandName="Edit"
                Text="Edit" />
        <br />
        <br />
    </ItemTemplate>
    <EditItemTemplate>
        Product name:
            <asp:TextBox ID="ProductName" runat="server"
                Text='<%# Eval("ProductName") %>' />
        <br />
        Price:
            <asp:TextBox ID="UnitPrice" runat="server"
                Text='<%# Eval("UnitPrice", "{0:C}") %>' />
        <br />
        <br />
            <asp:Button ID="UpdateProduct" runat="server" CommandName="Update"
                Text="Update" /> 
            <asp:Button ID="CancelUpdate" runat="server" CommandName="Cancel"
                Text="Cancel" />
    </EditItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="ProductsDataSource" runat="server"
    SelectMethod="GetProducts" TypeName="ProductsBLL"
    OldValuesParameterFormatString="original_{0}">
</asp:ObjectDataSource>
<asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID"
    DataSourceID="ObjectDataSource1" RepeatColumns="2">
    <ItemTemplate>
        <h5>
            <asp:Label runat="server" ID="ProductNameLabel"
                Text='<%# Eval("ProductName") %>' />
        </h5>
        Price: <asp:Label runat="server" ID="Label1"
                    Text='<%# Eval("UnitPrice", "{0:C}") %>' />
        <br />
        <br />
    </ItemTemplate>
    <EditItemTemplate>
        Product name:
            <asp:TextBox ID="ProductName" runat="server"
                Text='<%# Eval("ProductName") %>' /><br />
        Price:
            <asp:TextBox ID="UnitPrice" runat="server"
                Text='<%# Eval("UnitPrice", "{0:C}") %>' /><br />
        <br />
        <asp:Button ID="UpdateProduct" runat="server"
            CommandName="Update" Text="Update" /> 
        <asp:Button ID="CancelUpdate" runat="server"
            CommandName="Cancel" Text="Cancel" />
    </EditItemTemplate>
</asp:DataList>
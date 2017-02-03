<ItemTemplate>
    <h5>
        <asp:Label runat="server" ID="ProductNameLabel"
            Text='<%# Eval("ProductName") %>' />
    </h5>
    Price: <asp:Label runat="server" ID="Label1"
            Text='<%# Eval("UnitPrice", "{0:C}") %>' />
    <br />
    <asp:Button runat="server" id="EditProduct" CommandName="Edit"
        Text="Edit" />
     
    <asp:Button runat="server" id="DeleteProduct" CommandName="Delete"
        Text="Delete" />
    <br />
    <br />
</ItemTemplate>
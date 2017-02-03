<h4>
    <asp:Label ID="ProductNameLabel" runat="server"
        Text='<%# DisplayProductNameAndDiscontinuedStatus((string) Eval("ProductName"),
              (bool) Eval("Discontinued")) %>'>
    </asp:Label>
</h4>
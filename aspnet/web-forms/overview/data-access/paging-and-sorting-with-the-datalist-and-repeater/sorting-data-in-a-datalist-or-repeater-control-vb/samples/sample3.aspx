<asp:DropDownList ID="SortBy" runat="server">
    <asp:ListItem Value="ProductName">Name</asp:ListItem>
    <asp:ListItem Value="ProductName DESC">Name (Reverse Order)
        </asp:ListItem>
    <asp:ListItem Value="CategoryName">Category</asp:ListItem>
    <asp:ListItem Value="SupplierName">Supplier</asp:ListItem>
</asp:DropDownList>
<asp:Button runat="server" ID="RefreshRepeater" Text="Refresh" />
<ItemTemplate>
    <h4>
        <asp:Label ID="ProductNameLabel" runat="server"
            Text='<%# Eval("ProductName") %>' />
    </h4>
    <table border="0">
        <tr>
            <td class="ProductPropertyLabel">Category:</td>
            <td class="ProductPropertyValue">
                <asp:Label ID="CategoryNameLabel" runat="server"
                    Text='<%# Eval("CategoryName") %>' />
            </td>
            <td class="ProductPropertyLabel">Supplier:</td>
            <td class="ProductPropertyValue">
                <asp:Label ID="SupplierNameLabel" runat="server"
                    Text='<%# Eval("SupplierName") %>' />
            </td>
        </tr>
        <tr>
            <td class="ProductPropertyLabel">Discontinued:</td>
            <td class="ProductPropertyValue">
                <asp:Label ID="DiscontinuedLabel" runat="server"
                    Text='<%# Eval("Discontinued") %>' />
            </td>
            <td class="ProductPropertyLabel">Price:</td>
            <td class="ProductPropertyValue">
                <asp:Label ID="UnitPriceLabel" runat="server"
                    Text='<%# Eval("UnitPrice", "{0:C}") %>' />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button runat="Server" ID="EditButton"
                    Text="Edit" CommandName="Edit" />
            </td>
        </tr>
    </table>
    <br />
</ItemTemplate>
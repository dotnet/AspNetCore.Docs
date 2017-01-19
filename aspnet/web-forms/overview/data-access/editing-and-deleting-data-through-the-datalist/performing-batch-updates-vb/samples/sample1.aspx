<asp:DataList ID="Suppliers" runat="server" DataKeyField="SupplierID"
    DataSourceID="SuppliersDataSource">
    <ItemTemplate>
        <h4><asp:Label ID="CompanyNameLabel" runat="server"
            Text='<%# Eval("CompanyName") %>' /></h4>
        <table border="0">
            <tr>
                <td class="SupplierPropertyLabel">Address:</td>
                <td class="SupplierPropertyValue">
                    <asp:TextBox ID="Address" runat="server"
                        Text='<%# Eval("Address") %>' />
                </td>
            </tr>
            <tr>
                <td class="SupplierPropertyLabel">City:</td>
                <td class="SupplierPropertyValue">
                    <asp:TextBox ID="City" runat="server"
                        Text='<%# Eval("City") %>' />
                </td>
            </tr>
            <tr>
                <td class="SupplierPropertyLabel">Country:</td>
                <td class="SupplierPropertyValue">
                    <asp:TextBox ID="Country" runat="server"
                        Text='<%# Eval("Country") %>' />
                </td>
            </tr>
        </table>
        <br />
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetSuppliers" TypeName="SuppliersBLL">
</asp:ObjectDataSource>
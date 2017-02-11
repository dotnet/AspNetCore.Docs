<asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1"
    AllowPaging="True" EnableViewState="False">
    <ItemTemplate>
        <hr />
        <h3><%# Eval("ProductName") %></h3>
        <table border="0">
            <tr>
                <td class="ProductPropertyLabel">Category:</td>
                <td class="ProductPropertyValue">
                  <%# Eval("CategoryName") %></td>
                <td class="ProductPropertyLabel">Supplier:</td>
                <td class="ProductPropertyValue">
                  <%# Eval("SupplierName")%></td>
            </tr>
            <tr>
                <td class="ProductPropertyLabel">Price:</td>
                <td class="ProductPropertyValue"><%# Eval("UnitPrice",
                  "{0:C}") %></td>
                <td class="ProductPropertyLabel">Units In Stock:</td>
                <td class="ProductPropertyValue">
                  <%# Eval("UnitsInStock")%></td>
            </tr>
            <tr>
                <td class="ProductPropertyLabel">Units On Order:</td>
                <td class="ProductPropertyValue">
                  <%# Eval("UnitsOnOrder") %></td>
                <td class="ProductPropertyLabel">Reorder Level:</td>
                <td class="ProductPropertyValue">
                  <%# Eval("ReorderLevel")%></td>
            </tr>
            <tr>
                <td class="ProductPropertyLabel">Qty/Unit</td>
                <td class="ProductPropertyValue">
                  <%# Eval("QuantityPerUnit") %></td>
                <td class="ProductPropertyLabel">Discontinued:</td>
                <td class="ProductPropertyValue">
                    <asp:CheckBox runat="server" Enabled="false"
                      Checked='<%# Eval("Discontinued") %>' />
                </td>
            </tr>
        </table>
        <hr />
    </ItemTemplate>
</asp:FormView>
<asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID"
    DataSourceID="ProductsByCategoryDataSource" EnableViewState="False">
    <ItemTemplate>
        <h4>
            <asp:Label ID="ProductNameLabel" runat="server"
                Text='<%# Eval("ProductName") %>' />
        </h4>
        <table border="0">
            <tr>
                <td class="ProductPropertyLabel">Category:</td>
                <td><asp:Label ID="CategoryNameLabel" runat="server"
                    Text='<%# Eval("CategoryName") %>' /></td>
                <td class="ProductPropertyLabel">Supplier:</td>
                <td><asp:Label ID="SupplierNameLabel" runat="server"
                    Text='<%# Eval("SupplierName") %>' /></td>
            </tr>
            <tr>
                <td class="ProductPropertyLabel">Qty/Unit:</td>
                <td><asp:Label ID="QuantityPerUnitLabel" runat="server"
                    Text='<%# Eval("QuantityPerUnit") %>' /></td>
                <td class="ProductPropertyLabel">Price:</td>
                <td><asp:Label ID="UnitPriceLabel" runat="server"
                    Text='<%# Eval("UnitPrice", "{0:C}") %>' /></td>
            </tr>
        </table>
    </ItemTemplate>
    <SeparatorTemplate>
        <hr />
    </SeparatorTemplate>
</asp:DataList>
 
<asp:ObjectDataSource ID="ProductsByCategoryDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:ControlParameter ControlID="Categories" Name="categoryID"
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
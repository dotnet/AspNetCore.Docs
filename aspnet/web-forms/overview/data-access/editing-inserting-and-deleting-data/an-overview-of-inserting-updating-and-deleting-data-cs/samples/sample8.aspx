<asp:FormView ID="FormView1" runat="server" DataKeyNames="ProductID"
    DataSourceID="ObjectDataSource1" AllowPaging="True">
    <EditItemTemplate>
        ...
    </EditItemTemplate>
    <InsertItemTemplate>
        ...
    </InsertItemTemplate>
    <ItemTemplate>
        ProductID:
        <asp:Label ID="ProductIDLabel" runat="server"
            Text='<%# Eval("ProductID") %>'></asp:Label><br />
        ProductName:
        <asp:Label ID="ProductNameLabel" runat="server"
            Text='<%# Bind("ProductName") %>'>
        </asp:Label><br />
        SupplierID:
        <asp:Label ID="SupplierIDLabel" runat="server"
            Text='<%# Bind("SupplierID") %>'>
        </asp:Label><br />
        CategoryID:
        <asp:Label ID="CategoryIDLabel" runat="server"
            Text='<%# Bind("CategoryID") %>'>
        </asp:Label><br />
        QuantityPerUnit:
        <asp:Label ID="QuantityPerUnitLabel" runat="server"
            Text='<%# Bind("QuantityPerUnit") %>'>
        </asp:Label><br />
        UnitPrice:
        <asp:Label ID="UnitPriceLabel" runat="server"
            Text='<%# Bind("UnitPrice") %>'></asp:Label><br />
        UnitsInStock:
        <asp:Label ID="UnitsInStockLabel" runat="server"
            Text='<%# Bind("UnitsInStock") %>'>
        </asp:Label><br />
        UnitsOnOrder:
        <asp:Label ID="UnitsOnOrderLabel" runat="server"
            Text='<%# Bind("UnitsOnOrder") %>'>
        </asp:Label><br />
        ReorderLevel:
        <asp:Label ID="ReorderLevelLabel" runat="server"
            Text='<%# Bind("ReorderLevel") %>'>
        </asp:Label><br />
        Discontinued:
        <asp:CheckBox ID="DiscontinuedCheckBox" runat="server"
            Checked='<%# Bind("Discontinued") %>'
            Enabled="false" /><br />
        CategoryName:
        <asp:Label ID="CategoryNameLabel" runat="server"
            Text='<%# Bind("CategoryName") %>'>
        </asp:Label><br />
        SupplierName:
        <asp:Label ID="SupplierNameLabel" runat="server"
            Text='<%# Bind("SupplierName") %>'>
        </asp:Label><br />
        <asp:LinkButton ID="EditButton" runat="server"
            CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton>
        <asp:LinkButton ID="DeleteButton" runat="server"
            CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton>
        <asp:LinkButton ID="NewButton" runat="server"
            CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton>
    </ItemTemplate>
</asp:FormView>
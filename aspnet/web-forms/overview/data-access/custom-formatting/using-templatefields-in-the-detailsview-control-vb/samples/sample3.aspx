<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" AllowPaging="True"
    EnableViewState="False">
    <Fields>
        <asp:BoundField DataField="ProductName"
          HeaderText="Product" SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category"
          ReadOnly="True" SortExpression="CategoryName" />
        <asp:BoundField DataField="SupplierName"
          HeaderText="Supplier" ReadOnly="True"
          SortExpression="SupplierName" />
        <asp:BoundField DataField="QuantityPerUnit"
          HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
        <asp:TemplateField HeaderText="Price and Inventory">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server"
                  Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                <br />
                <strong>
                (In Stock / On Order: </strong>
                <asp:Label ID="Label2" runat="server"
                  Text='<%# Eval("UnitsInStock") %>'></asp:Label>
                <strong>/</strong>
                <asp:Label ID="Label3" runat="server"
                  Text='<%# Eval("UnitsOnOrder") %>'>
                </asp:Label><strong>)</strong>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="Discontinued"
           HeaderText="Discontinued" SortExpression="Discontinued" />
    </Fields>
</asp:DetailsView>
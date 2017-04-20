<asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
    <EditItemTemplate>
        ...
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="DummyCategoryID" runat="server"
            Text='<%# Bind("CategoryID") %>' Visible="False"></asp:Label>
        <asp:Label ID="Label2" runat="server"
            Text='<%# Eval("CategoryName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Supplier" SortExpression="SupplierName">
    <EditItemTemplate>
        ...
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="DummySupplierID" runat="server"
            Text='<%# Bind("SupplierID") %>' Visible="False"></asp:Label>
        <asp:Label ID="Label3" runat="server"
            Text='<%# Eval("SupplierName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
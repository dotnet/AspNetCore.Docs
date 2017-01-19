<asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
    <EditItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server"
         Text='<%# Bind("ProductName") %>'></asp:TextBox>
    </EditItemTemplate>
    <InsertItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server"
         Text='<%# Bind("ProductName") %>'></asp:TextBox>
    </InsertItemTemplate>
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server"
         Text='<%# Bind("ProductName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
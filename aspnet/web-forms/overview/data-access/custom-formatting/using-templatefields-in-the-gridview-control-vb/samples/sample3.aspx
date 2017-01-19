<asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
    <EditItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server"
            Text='<%# Bind("FirstName") %>'></asp:TextBox>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server"
            Text='<%# Bind("FirstName") %>'></asp:Label>
        <asp:Label ID="Label2" runat="server"
            Text='<%# Bind("LastName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
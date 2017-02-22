<asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
    <EditItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server"
            Text='<%# Bind("FirstName") %>'></asp:TextBox>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server"
            Text='<%# Bind("FirstName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
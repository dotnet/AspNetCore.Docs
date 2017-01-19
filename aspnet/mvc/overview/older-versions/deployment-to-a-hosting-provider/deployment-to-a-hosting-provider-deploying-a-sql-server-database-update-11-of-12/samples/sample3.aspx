<asp:TemplateField HeaderText="Office Hours">
    <ItemTemplate>
        <asp:Label ID="InstructorOfficeHoursLabel" runat="server" Text='<%# Eval("OfficeHours") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="InstructorOfficeHoursTextBox" runat="server" Text='<%# Bind("OfficeHours") %>'
            Width="14em"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
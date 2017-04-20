<asp:TemplateField HeaderText="Hire Date" SortExpression="HireDate">
    <ItemTemplate>
        <asp:Label ID="InstructorHireDateLabel" runat="server" Text='<%# Eval("HireDate", "{0:d}") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="InstructorHireDateTextBox" runat="server" Text='<%# Bind("HireDate", "{0:d}") %>' Width="7em"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Birth Date" SortExpression="BirthDate">
    <ItemTemplate>
        <asp:Label ID="InstructorBirthDateLabel" runat="server" Text='<%# Eval("BirthDate", "{0:d}") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="InstructorBirthDateTextBox" runat="server" Text='<%# Bind("BirthDate", "{0:d}") %>'
            Width="7em"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Office Assignment" SortExpression="OfficeAssignment.Location">
    <ItemTemplate>
        <asp:Label ID="InstructorOfficeLabel" runat="server" Text='<%# Eval("OfficeAssignment.Location") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="InstructorOfficeTextBox" runat="server"
            Text='<%# Eval("OfficeAssignment.Location") %>' Width="7em"
            OnInit="InstructorOfficeTextBox_Init"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" SortExpression="LastName">
                <EditItemTemplate>
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstMidName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>,
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstMidName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
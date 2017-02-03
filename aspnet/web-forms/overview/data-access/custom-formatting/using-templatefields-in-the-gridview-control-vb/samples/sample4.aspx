<asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False" DataKeyNames="EmployeeID"
    DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"
                    Text='<%# Bind("FirstName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server"
                    Text='<%# Bind("FirstName") %>'></asp:Label>
                <asp:Label ID="Label2" runat="server"
                    Text='<%# Eval("LastName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Title" HeaderText="Title"
            SortExpression="" Title" />
        <asp:BoundField DataField="HireDate" HeaderText="
            HireDate" SortExpression="" HireDate" />
    </Columns>
</asp:GridView>
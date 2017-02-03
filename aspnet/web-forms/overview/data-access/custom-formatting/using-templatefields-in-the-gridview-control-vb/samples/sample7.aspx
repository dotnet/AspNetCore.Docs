<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="EmployeeID" DataSourceID="ObjectDataSource1">
    <Columns>
        <asp:TemplateField HeaderText="Name"
          SortExpression="FirstName">
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
        <asp:BoundField DataField="Title" HeaderText="" Title"
            SortExpression="Title" />
        <asp:TemplateField HeaderText="HireDate" SortExpression="
            HireDate">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server"
                    Text='<%# Bind("HireDate") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Calendar ID="Calendar1" runat="server"
                    SelectedDate='<%# Bind("HireDate") %>'
                    VisibleDate='<%# Eval("HireDate") %>'>
                </asp:Calendar>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Days On The Job">
            <ItemTemplate>
                <%# DisplayDaysOnJob(CType(CType(Container.DataItem, DataRowView).Row,
                    Northwind.EmployeesRow)) %>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
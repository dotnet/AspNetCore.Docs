<h2>Departments</h2>
    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.DAL.SchoolRepository" 
        DataObjectTypeName="ContosoUniversity.DAL.Department" 
        SelectMethod="GetDepartments" >
    </asp:ObjectDataSource>
    <asp:GridView ID="DepartmentsGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="DepartmentsObjectDataSource"  >
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"
                ItemStyle-VerticalAlign="Top">
            </asp:CommandField>
            <asp:DynamicField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-VerticalAlign="Top" />
            <asp:DynamicField DataField="Budget" HeaderText="Budget" SortExpression="Budget" ItemStyle-VerticalAlign="Top" />
            <asp:DynamicField DataField="StartDate" HeaderText="Start Date" ItemStyle-VerticalAlign="Top" />
            <asp:TemplateField HeaderText="Administrator" SortExpression="Person.LastName" ItemStyle-VerticalAlign="Top" >
                <ItemTemplate>
                    <asp:Label ID="AdministratorLastNameLabel" runat="server" Text='<%# Eval("Person.LastName") %>'></asp:Label>,
                    <asp:Label ID="AdministratorFirstNameLabel" runat="server" Text='<%# Eval("Person.FirstMidName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
<asp:GridView ID="CoursesGridView" runat="server" 
            DataSourceID="CoursesEntityDataSource"
            AllowSorting="True" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="LightGray" 
            DataKeyNames="CourseID">
            <EmptyDataTemplate>
                <p>No courses found.</p>
            </EmptyDataTemplate>
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" SortExpression="CourseID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:TemplateField HeaderText="Department" SortExpression="DepartmentID">
                    <ItemTemplate>
                        <asp:Label ID="GridViewDepartmentLabel" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
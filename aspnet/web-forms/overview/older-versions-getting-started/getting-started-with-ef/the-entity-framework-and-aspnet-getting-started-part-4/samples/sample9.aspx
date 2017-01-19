<div>
        <h3>Course Details</h3>
        <asp:EntityDataSource ID="CourseDetailsEntityDataSource" runat="server" 
            ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
            EntitySetName="Courses"
            AutoGenerateWhereClause="False" Where="it.CourseID = @CourseID" Include="Department,OnlineCourse,OnsiteCourse,StudentGrades.Person"
            OnSelected="CourseDetailsEntityDataSource_Selected">
            <WhereParameters>
                <asp:ControlParameter ControlID="CoursesGridView" Type="Int32" Name="CourseID" PropertyName="SelectedValue" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:DetailsView ID="CourseDetailsView" runat="server" AutoGenerateRows="False"
            DataSourceID="CourseDetailsEntityDataSource">
            <EmptyDataTemplate>
                <p>
                    No course selected.</p>
            </EmptyDataTemplate>
            <Fields>
                <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" SortExpression="CourseID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
                <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label ID="DetailsViewDepartmentLabel" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("OnsiteCourse.Location") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="URL">
                    <ItemTemplate>
                        <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("OnlineCourse.URL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    </div>
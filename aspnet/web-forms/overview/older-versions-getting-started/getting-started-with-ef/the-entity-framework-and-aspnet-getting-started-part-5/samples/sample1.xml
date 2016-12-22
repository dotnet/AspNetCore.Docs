<h2>Add Courses</h2>
    <asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False"
        EntitySetName="Courses" 
        EnableInsert="True" EnableDelete="True" >
    </asp:EntityDataSource>
    <asp:DetailsView ID="CoursesDetailsView" runat="server" AutoGenerateRows="False"
        DataSourceID="CoursesEntityDataSource" DataKeyNames="CourseID"
        DefaultMode="Insert" oniteminserting="CoursesDetailsView_ItemInserting">
        <Fields>
            <asp:BoundField DataField="CourseID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" />
            <asp:TemplateField HeaderText="Department">
                <InsertItemTemplate>
                    <asp:EntityDataSource ID="DepartmentsEntityDataSource" runat="server" ConnectionString="name=SchoolEntities"
                        DefaultContainerName="SchoolEntities" EnableDelete="True" EnableFlattening="False"
                        EntitySetName="Departments" EntityTypeFilter="Department">
                    </asp:EntityDataSource>
                    <asp:DropDownList ID="DepartmentsDropDownList" runat="server" DataSourceID="DepartmentsEntityDataSource"
                        DataTextField="Name" DataValueField="DepartmentID"
                        oninit="DepartmentsDropDownList_Init">
                    </asp:DropDownList>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
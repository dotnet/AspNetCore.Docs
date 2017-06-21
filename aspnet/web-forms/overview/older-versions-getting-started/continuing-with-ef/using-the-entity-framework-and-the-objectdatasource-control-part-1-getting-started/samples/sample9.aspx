<h2>Departments</h2>
    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.DAL.SchoolRepository" DataObjectTypeName="ContosoUniversity.DAL.Department"
        InsertMethod="InsertDepartment" >
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DepartmentsDetailsView" runat="server" 
        DataSourceID="DepartmentsObjectDataSource" AutoGenerateRows="False"
        DefaultMode="Insert" OnItemInserting="DepartmentsDetailsView_ItemInserting">
        <Fields>
            <asp:DynamicField DataField="Name" HeaderText="Name" />
            <asp:DynamicField DataField="Budget" HeaderText="Budget" />
            <asp:DynamicField DataField="StartDate" HeaderText="Start Date" />
            <asp:TemplateField HeaderText="Administrator">
                <InsertItemTemplate>
                    <asp:ObjectDataSource ID="InstructorsObjectDataSource" runat="server" 
                        TypeName="ContosoUniversity.DAL.SchoolRepository" 
                        DataObjectTypeName="ContosoUniversity.DAL.InstructorName"
                        SelectMethod="GetInstructorNames" >
                    </asp:ObjectDataSource>
                    <asp:DropDownList ID="InstructorsDropDownList" runat="server" 
                        DataSourceID="InstructorsObjectDataSource"
                        DataTextField="FullName" DataValueField="PersonID" OnInit="DepartmentsDropDownList_Init">
                    </asp:DropDownList>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
   <asp:ValidationSummary ID="DepartmentsValidationSummary" runat="server" 
        ShowSummary="true" DisplayMode="BulletList"  />
<asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CourseID,Title,Credits,DepartmentID"
        DataSourceID="CoursesEntityDataSource" >
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" ReadOnly="True" SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
        </Columns>
    </asp:GridView>
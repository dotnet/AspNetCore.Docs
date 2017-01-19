<asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CourseID" DataSourceID="CoursesEntityDataSource">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" 
                SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" 
                SortExpression="Credits" />
        </Columns>
    </asp:GridView>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Students</h2>
    <asp:EntityDataSource ID="StudentsEntityDataSource" runat="server"
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False"
        EnableInsert="True" EntitySetName="People">
    </asp:EntityDataSource>
    <asp:DetailsView ID="StudentsDetailsView" runat="server" 
        DataSourceID="StudentsEntityDataSource" AutoGenerateRows="False"
        DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" 
                SortExpression="FirstMidName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                SortExpression="LastName" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" 
                SortExpression="EnrollmentDate" />
             <asp:CommandField ShowInsertButton="True" />
       </Fields>
    </asp:DetailsView>
</asp:Content>
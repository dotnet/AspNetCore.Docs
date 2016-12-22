<h2>Student Body Statistics</h2>
    <asp:ObjectDataSource ID="StudentStatisticsObjectDataSource" runat="server" TypeName="ContosoUniversity.BLL.SchoolBL"
        SelectMethod="GetStudentStatistics" DataObjectTypeName="ContosoUniversity.DAL.EnrollmentDateGroup">
    </asp:ObjectDataSource>
    <asp:GridView ID="StudentStatisticsGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="StudentStatisticsObjectDataSource">
        <Columns>
            <asp:BoundField DataField="EnrollmentDate" DataFormatString="{0:d}" HeaderText="Date of Enrollment"
                ReadOnly="True" SortExpression="EnrollmentDate" />
            <asp:BoundField DataField="StudentCount" HeaderText="Students" ReadOnly="True"
                SortExpression="StudentCount" />
        </Columns>
    </asp:GridView>
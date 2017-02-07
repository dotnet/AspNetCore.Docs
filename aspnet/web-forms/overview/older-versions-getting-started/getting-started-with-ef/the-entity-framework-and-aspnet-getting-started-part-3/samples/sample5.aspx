<asp:GridView ID="StudentStatisticsGridView" runat="server" AutoGenerateColumns="False" 
        DataSourceID="StudentStatisticsEntityDataSource">
        <Columns>
            <asp:BoundField DataField="EnrollmentDate" DataFormatString="{0:d}" 
                HeaderText="Date of Enrollment" 
                ReadOnly="True" SortExpression="EnrollmentDate" />
            <asp:BoundField DataField="NumberOfStudents" HeaderText="Students" 
                ReadOnly="True" SortExpression="NumberOfStudents" />
        </Columns>
    </asp:GridView>
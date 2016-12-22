<asp:EntityDataSource ID="StudentStatisticsEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
        EntitySetName="People" EntityTypeFilter="Student"
        Select="it.EnrollmentDate, Count(it.EnrollmentDate) AS NumberOfStudents"
        OrderBy="it.EnrollmentDate" GroupBy="it.EnrollmentDate" >
    </asp:EntityDataSource>
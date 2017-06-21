<asp:EntityDataSource ID="StudentStatisticsEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
        EntitySetName="People"
        Select="it.EnrollmentDate, Count(it.EnrollmentDate) AS NumberOfStudents" 
        OrderBy="it.EnrollmentDate" GroupBy="it.EnrollmentDate"
        Where="it.EnrollmentDate is not null" >
    </asp:EntityDataSource>
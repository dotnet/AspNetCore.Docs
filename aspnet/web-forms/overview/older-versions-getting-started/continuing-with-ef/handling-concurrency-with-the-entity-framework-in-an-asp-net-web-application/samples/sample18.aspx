<asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="false"
        AutoGenerateWhereClause="true" EntitySetName="Courses" 
        EnableUpdate="true" EnableDelete="true" 
        OnDeleted="CoursesEntityDataSource_Deleted" 
        OnUpdated="CoursesEntityDataSource_Updated">
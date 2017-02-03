<asp:EntityDataSource ID="InstructorsEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
        EntitySetName="People" EntityTypeFilter="Instructor" 
        Select="it.LastName + ',' + it.FirstMidName AS Name, it.PersonID">
    </asp:EntityDataSource>
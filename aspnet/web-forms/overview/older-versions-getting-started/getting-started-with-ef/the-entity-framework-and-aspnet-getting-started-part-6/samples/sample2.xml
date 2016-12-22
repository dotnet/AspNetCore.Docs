<asp:EntityDataSource ID="SearchEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
        EntitySetName="People" EntityTypeFilter="Student"
        Where="it.FirstMidName Like '%' + @StudentName + '%' or it.LastName Like '%' + @StudentName + '%'" >
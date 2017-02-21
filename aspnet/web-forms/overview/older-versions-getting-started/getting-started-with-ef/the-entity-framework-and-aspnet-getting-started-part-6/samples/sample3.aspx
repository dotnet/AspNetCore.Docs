<asp:EntityDataSource ID="StudentsEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False"
        EntitySetName="People" EntityTypeFilter="Student"
        EnableInsert="True" 
    </asp:EntityDataSource>
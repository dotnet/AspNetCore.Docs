<asp:EntityDataSource ID="InstructorsEntityDataSource" runat="server" 
            ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="false"
            EntitySetName="People" EntityTypeFilter="Instructor" 
            Include="OfficeAssignment" 
            EnableUpdate="True">
        </asp:EntityDataSource>
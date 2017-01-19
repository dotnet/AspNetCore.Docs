<h2>Instructors</h2>
    <div>
        <asp:EntityDataSource ID="InstructorsEntityDataSource" runat="server" 
            ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
            EntitySetName="People"
            Where="it.HireDate is not null" Include="OfficeAssignment" EnableUpdate="True">
        </asp:EntityDataSource>
    </div>
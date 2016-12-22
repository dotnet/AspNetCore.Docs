<h3>Courses Taught</h3>
        <asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" 
            ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
            EntitySetName="Courses" 
            Where="@PersonID IN (SELECT VALUE instructor.PersonID FROM it.People AS instructor)">
            <WhereParameters>
                <asp:ControlParameter ControlID="InstructorsGridView" Type="Int32" Name="PersonID" PropertyName="SelectedValue" />
            </WhereParameters>
        </asp:EntityDataSource>
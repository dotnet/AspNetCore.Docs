<h2>Office Assignments</h2>
    <asp:ObjectDataSource ID="OfficeAssignmentsObjectDataSource" runat="server" TypeName="ContosoUniversity.BLL.SchoolBL"
        DataObjectTypeName="ContosoUniversity.DAL.OfficeAssignment" SelectMethod="GetOfficeAssignments"
        DeleteMethod="DeleteOfficeAssignment" UpdateMethod="UpdateOfficeAssignment" ConflictDetection="CompareAllValues"
        OldValuesParameterFormatString="orig{0}"
        SortParameterName="sortExpression"  OnUpdated="OfficeAssignmentsObjectDataSource_Updated">
    </asp:ObjectDataSource>
    <asp:ValidationSummary ID="OfficeAssignmentsValidationSummary" runat="server" ShowSummary="true"
        DisplayMode="BulletList" Style="color: Red; width: 40em;" />
    <asp:GridView ID="OfficeAssignmentsGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="OfficeAssignmentsObjectDataSource" DataKeyNames="InstructorID,Timestamp"
        AllowSorting="True">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ItemStyle-VerticalAlign="Top">
                <ItemStyle VerticalAlign="Top"></ItemStyle>
            </asp:CommandField>
            <asp:TemplateField HeaderText="Instructor" SortExpression="Person.LastName">
                <ItemTemplate>
                    <asp:Label ID="InstructorLastNameLabel" runat="server" Text='<%# Eval("Person.LastName") %>'></asp:Label>,
                    <asp:Label ID="InstructorFirstNameLabel" runat="server" Text='<%# Eval("Person.FirstMidName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="Location" HeaderText="Location" SortExpression="Location"/>
        </Columns>
        <SelectedRowStyle BackColor="LightGray"></SelectedRowStyle>
    </asp:GridView>
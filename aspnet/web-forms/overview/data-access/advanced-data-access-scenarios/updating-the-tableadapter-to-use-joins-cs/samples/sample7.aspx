<asp:GridView ID="Employees" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="EmployeeID" DataSourceID="EmployeesDataSource">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" />
        <asp:BoundField DataField="Title" 
            HeaderText="Title" 
            SortExpression="Title" />
        <asp:BoundField DataField="LastName" 
            HeaderText="Last Name" 
            SortExpression="LastName" />
        <asp:BoundField DataField="FirstName" 
            HeaderText="First Name" 
            SortExpression="FirstName" />
        <asp:BoundField DataField="ManagerFirstName" 
            HeaderText="Manager's First Name" 
            SortExpression="ManagerFirstName" />
        <asp:BoundField DataField="ManagerLastName" 
            HeaderText="Manager's Last Name" 
            SortExpression="ManagerLastName" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="EmployeesDataSource" runat="server" 
    DeleteMethod="DeleteEmployee" OldValuesParameterFormatString="{0}" 
    SelectMethod="GetEmployees" TypeName="EmployeesBLLWithSprocs">
    <DeleteParameters>
        <asp:Parameter Name="employeeID" Type="Int32" />
    </DeleteParameters>
</asp:ObjectDataSource>
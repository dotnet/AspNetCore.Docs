<asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.DAL.SchoolRepository" 
        DataObjectTypeName="ContosoUniversity.DAL.Department"
        SelectMethod="GetDepartments" 
        DeleteMethod="DeleteDepartment" >

    <asp:GridView ID="DepartmentsGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="DepartmentsObjectDataSource" DataKeyNames="DepartmentID" >
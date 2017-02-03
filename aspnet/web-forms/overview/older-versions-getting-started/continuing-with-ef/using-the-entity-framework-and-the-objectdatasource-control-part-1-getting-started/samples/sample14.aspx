<asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.DAL.SchoolRepository" 
        DataObjectTypeName="ContosoUniversity.DAL.Department" 
        SelectMethod="GetDepartments" DeleteMethod="DeleteDepartment" 
        UpdateMethod="UpdateDepartment"
        ConflictDetection="CompareAllValues" 
        OldValuesParameterFormatString="orig{0}" >
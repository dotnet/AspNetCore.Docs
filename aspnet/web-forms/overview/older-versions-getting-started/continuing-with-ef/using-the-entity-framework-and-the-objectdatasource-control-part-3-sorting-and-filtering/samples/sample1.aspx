<asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Department" 
        SelectMethod="GetDepartments" DeleteMethod="DeleteDepartment" UpdateMethod="UpdateDepartment"
        ConflictDetection="CompareAllValues" OldValuesParameterFormatString="orig{0}" 
        OnUpdated="DepartmentsObjectDataSource_Updated" SortParameterName="sortExpression" >
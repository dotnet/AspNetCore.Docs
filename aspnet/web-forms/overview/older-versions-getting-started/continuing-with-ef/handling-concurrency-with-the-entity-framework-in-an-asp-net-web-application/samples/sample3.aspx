<asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Department" 
        SelectMethod="GetDepartmentsByName" DeleteMethod="DeleteDepartment" UpdateMethod="UpdateDepartment"
        ConflictDetection="CompareAllValues" OldValuesParameterFormatString="orig{0}" 
        OnUpdated="DepartmentsObjectDataSource_Updated" SortParameterName="sortExpression" 
        OnDeleted="DepartmentsObjectDataSource_Deleted" >
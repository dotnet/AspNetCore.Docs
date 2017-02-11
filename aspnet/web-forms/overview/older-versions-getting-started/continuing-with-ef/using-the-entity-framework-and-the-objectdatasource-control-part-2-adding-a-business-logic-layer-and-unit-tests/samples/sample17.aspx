<asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Department" 
        InsertMethod="InsertDepartment"  
        OnInserted="DepartmentsObjectDataSource_Inserted">
<asp:GridView ID="DepartmentsGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="DepartmentsObjectDataSource" DataKeyNames="DepartmentID" 
        OnRowUpdating="DepartmentsGridView_RowUpdating"
        OnRowDataBound="DepartmentsGridView_RowDataBound"
        AllowSorting="True" >
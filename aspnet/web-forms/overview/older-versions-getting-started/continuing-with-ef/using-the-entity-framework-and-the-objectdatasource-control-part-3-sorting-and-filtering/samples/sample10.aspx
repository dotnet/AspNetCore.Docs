<asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" TypeName="ContosoUniversity.BLL.SchoolBL"
        SelectMethod="GetDepartmentsByName" DeleteMethod="DeleteDepartment" UpdateMethod="UpdateDepartment"
        DataObjectTypeName="ContosoUniversity.DAL.Department" ConflictDetection="CompareAllValues"
        SortParameterName="sortExpression" OldValuesParameterFormatString="orig{0}" 
        OnUpdated="DepartmentsObjectDataSource_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="SearchTextBox" Name="nameSearchString" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, False)> _
Public Function GetEmployeesByHiredDateMonth(ByVal month As Integer) _
    As Northwind.EmployeesDataTable
    Return Adapter.GetEmployeesByHiredDateMonth(month)
End Function
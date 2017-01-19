Imports NorthwindWithSprocsTableAdapters
<System.ComponentModel.DataObject()> _
Public Class EmployeesBLLWithSprocs
    Private _employeesAdapter As EmployeesTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As EmployeesTableAdapter
        Get
            If _employeesAdapter Is Nothing Then
                _employeesAdapter = New EmployeesTableAdapter()
            End If
            Return _employeesAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployees() As NorthwindWithSprocs.EmployeesDataTable
        Return Adapter.GetEmployees()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteEmployee(ByVal employeeID As Integer) As Boolean
        Dim rowsAffected = Adapter.Delete(employeeID)
        'Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
End Class
Protected Function DisplayDaysOnJob(employee As Northwind.EmployeesRow) As String
    ' Make sure HiredDate is not NULL... if so, return "Unknown"
    If employee.IsHireDateNull() Then
        Return "Unknown"
    Else
        ' Returns the number of days between the current
        ' date/time and HireDate
        Dim ts As TimeSpan = DateTime.Now.Subtract(employee.HireDate)
        Return ts.Days.ToString("#,##0")
    End If
End Function
' Create the command
Dim myCommand As New SqlCommand()
myCommand.CommandText = _
    "SELECT ProductID, ProductName, SupplierID, CategoryID, " & _
    "       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, " & _
    "       ReorderLevel, Discontinued " & _
    "FROM Products " & _
    "WHERE Discontinued = 1"
' Execute the command and send back the results
SqlContext.Pipe.ExecuteAndSend(myCommand)
<Microsoft.SqlServer.Server.SqlProcedure()> _
Public Shared Sub GetProductsWithPriceLessThan(ByVal price As SqlMoney)
    'Create the command
    Dim myCommand As New SqlCommand()
    myCommand.CommandText = _
        "SELECT ProductID, ProductName, SupplierID, CategoryID, " & _
        "       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, " & _
        "       ReorderLevel, Discontinued " & _
        "FROM Products " & _
        "WHERE UnitPrice < @MaxPrice"
    myCommand.Parameters.AddWithValue("@MaxPrice", price)
    ' Execute the command and send back the results
    SqlContext.Pipe.ExecuteAndSend(myCommand)
End Sub
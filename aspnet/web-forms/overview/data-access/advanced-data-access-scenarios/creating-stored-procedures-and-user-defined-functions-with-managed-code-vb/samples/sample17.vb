Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Partial Public Class StoredProcedures
    <Microsoft.SqlServer.Server.SqlProcedure()> _
    Public Shared Sub GetProductsWithPriceGreaterThan(ByVal price As SqlMoney)
        'Create the command
        Dim myCommand As New SqlCommand()
        myCommand.CommandText = _
            "SELECT ProductID, ProductName, SupplierID, CategoryID, " & _
            "       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, " & _
            "       ReorderLevel, Discontinued " & _
            "FROM Products " & _
            "WHERE UnitPrice > @MinPrice"
        myCommand.Parameters.AddWithValue("@MinPrice", price)
        ' Execute the command and send back the results
        SqlContext.Pipe.ExecuteAndSend(myCommand)
    End Sub
End Class
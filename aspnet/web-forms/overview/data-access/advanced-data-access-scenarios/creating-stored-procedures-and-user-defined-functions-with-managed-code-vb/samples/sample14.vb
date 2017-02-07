<Microsoft.SqlServer.Server.SqlFunction()> _
Public Shared Function udf_ComputeInventoryValue_Managed _
    (UnitPrice As SqlMoney, UnitsInStock As SqlInt16, Discontinued As SqlBoolean) _
    As SqlMoney
    Dim inventoryValue As SqlMoney = 0
    If Not UnitPrice.IsNull AndAlso Not UnitsInStock.IsNull Then
        inventoryValue = UnitPrice * UnitsInStock
        If Discontinued = True Then
            inventoryValue = inventoryValue * New SqlMoney(0.5)
        End If
    End If
    Return inventoryValue
End Function
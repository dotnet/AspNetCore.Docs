[Microsoft.SqlServer.Server.SqlFunction]
public static SqlMoney udf_ComputeInventoryValue_Managed
    (SqlMoney UnitPrice, SqlInt16 UnitsInStock, SqlBoolean Discontinued)
{
    SqlMoney inventoryValue = 0;
    if (!UnitPrice.IsNull && !UnitsInStock.IsNull)
    {
        inventoryValue = UnitPrice * UnitsInStock;
        if (Discontinued == true)
            inventoryValue = inventoryValue * new SqlMoney(0.5);
    }
    return inventoryValue;
}
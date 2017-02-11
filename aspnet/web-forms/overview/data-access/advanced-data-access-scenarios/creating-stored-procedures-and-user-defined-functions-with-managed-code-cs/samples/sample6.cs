[Microsoft.SqlServer.Server.SqlProcedure]
public static void GetProductsWithPriceLessThan(SqlMoney price)
{
    // Create the command
    SqlCommand myCommand = new SqlCommand();
    myCommand.CommandText =
          @"SELECT ProductID, ProductName, SupplierID, CategoryID, 
                   QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
                   ReorderLevel, Discontinued
            FROM Products
            WHERE UnitPrice < @MaxPrice";
    myCommand.Parameters.AddWithValue("@MaxPrice", price);
    // Execute the command and send back the results
    SqlContext.Pipe.ExecuteAndSend(myCommand);
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void GetProductsWithPriceGreaterThan(SqlMoney price)
    {
        // Create the command
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText =
            @"SELECT ProductID, ProductName, SupplierID, CategoryID, 
                     QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
                     ReorderLevel, Discontinued
              FROM Products
              WHERE UnitPrice > @MinPrice";
        myCommand.Parameters.AddWithValue("@MinPrice", price);
        // Execute the command and send back the results
        SqlContext.Pipe.ExecuteAndSend(myCommand);
    }
};
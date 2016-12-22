// Create the command
SqlCommand myCommand = new SqlCommand();
myCommand.CommandText = 
      @"SELECT ProductID, ProductName, SupplierID, CategoryID, 
               QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
               ReorderLevel, Discontinued
        FROM Products 
        WHERE Discontinued = 1";
// Execute the command and send back the results
SqlContext.Pipe.ExecuteAndSend(myCommand);
UPDATE [Products] SET
     [ProductName] = @ProductName,
     [UnitPrice] = @UnitPrice,
     [Discontinued] = @Discontinued
WHERE
     [ProductID] = @original_ProductID AND
     [ProductName] = @original_ProductName AND
     [UnitPrice] = @original_UnitPrice AND
     [Discontinued] = @original_Discontinued
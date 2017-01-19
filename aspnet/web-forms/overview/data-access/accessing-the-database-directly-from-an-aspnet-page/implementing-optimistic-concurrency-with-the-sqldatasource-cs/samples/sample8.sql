UPDATE [Products] SET
     [ProductName] = @ProductName,
     [UnitPrice] = @UnitPrice,
     [Discontinued] = @Discontinued
WHERE
     [ProductID] = @original_ProductID AND
     [ProductName] = @original_ProductName AND
     (([UnitPrice] IS NULL AND @original_UnitPrice IS NULL)
        OR ([UnitPrice] = @original_UnitPrice)) AND
     [Discontinued] = @original_Discontinued
DELETE FROM [Products]
WHERE
     [ProductID] = @original_ProductID AND
     [ProductName] = @original_ProductName AND
     (([UnitPrice] IS NULL AND @original_UnitPrice IS NULL)
        OR ([UnitPrice] = @original_UnitPrice)) AND
     [Discontinued] = @original_Discontinued
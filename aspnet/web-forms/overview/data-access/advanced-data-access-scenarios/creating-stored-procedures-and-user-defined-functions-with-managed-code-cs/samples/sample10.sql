SELECT ProductID, ProductName, dbo.udf_ComputeInventoryValue
    (UnitPrice, UnitsInStock, Discontinued) as InventoryValue
FROM Products
ORDER BY InventoryValue DESC
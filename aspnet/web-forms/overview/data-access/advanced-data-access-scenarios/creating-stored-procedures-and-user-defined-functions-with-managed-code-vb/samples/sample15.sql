SELECT ProductID, ProductName, 
       dbo.udf_ComputeInventoryValue_Managed(
                 UnitPrice, 
                 UnitsInStock, 
                 Discontinued
              ) as InventoryValue
FROM Products
ORDER BY InventoryValue DESC
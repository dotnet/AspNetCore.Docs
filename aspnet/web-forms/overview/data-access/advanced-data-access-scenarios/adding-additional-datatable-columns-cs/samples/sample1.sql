SELECT ProductID, ProductName, SupplierID, CategoryID, 
       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
       ReorderLevel, Discontinued,
       NTILE(4) OVER (ORDER BY UnitPrice DESC) as PriceQuartile
FROM Products
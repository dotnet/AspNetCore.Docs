CREATE PROCEDURE dbo.Products_SelectByCategoryID 
(
    @CategoryID int
)
AS
SELECT ProductID, ProductName, SupplierID, CategoryID, 
       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
       ReorderLevel, Discontinued
FROM Products
WHERE CategoryID = @CategoryID
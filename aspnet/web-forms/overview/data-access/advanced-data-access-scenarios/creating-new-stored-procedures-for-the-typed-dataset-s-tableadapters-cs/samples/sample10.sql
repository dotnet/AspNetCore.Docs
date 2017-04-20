ALTER PROCEDURE dbo.Products_SelectByProductID
(
    @ProductID int
)
AS
    SET NOCOUNT ON;
SELECT ProductID, ProductName, SupplierID, CategoryID, 
       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
       ReorderLevel, Discontinued
FROM Products
WHERE ProductID = @ProductID
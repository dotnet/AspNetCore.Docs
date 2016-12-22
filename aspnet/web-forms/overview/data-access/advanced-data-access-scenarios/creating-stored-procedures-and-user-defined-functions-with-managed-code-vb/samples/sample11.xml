CREATE FUNCTION dbo.udf_GetProductsByCategoryID
(    
    @CategoryID int
)
RETURNS TABLE 
AS
RETURN 
(
    SELECT ProductID, ProductName, SupplierID, CategoryID, 
           QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
           ReorderLevel, Discontinued
    FROM Products
    WHERE CategoryID = @CategoryID
)
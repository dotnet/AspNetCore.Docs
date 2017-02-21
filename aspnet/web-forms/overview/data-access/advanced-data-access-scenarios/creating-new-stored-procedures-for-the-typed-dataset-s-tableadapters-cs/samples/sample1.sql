CREATE PROCEDURE GetProductsByCategoryID
(
    @CategoryID int
)
AS
SELECT ProductID, ProductName, UnitPrice, Discontinued
FROM Products
WHERE CategoryID = @CategoryID
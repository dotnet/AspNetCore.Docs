ALTER PROCEDURE dbo.Products_Insert
(
    @ProductName nvarchar(40),
    @SupplierID int,
    @CategoryID int,
    @QuantityPerUnit nvarchar(20),
    @UnitPrice money,
    @UnitsInStock smallint,
    @UnitsOnOrder smallint,
    @ReorderLevel smallint,
    @Discontinued bit
)
AS
    SET NOCOUNT OFF;
INSERT INTO [Products] ([ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], 
    [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) 
VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, 
    @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);
    
SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, 
    UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued 
FROM Products 
WHERE (ProductID = SCOPE_IDENTITY())
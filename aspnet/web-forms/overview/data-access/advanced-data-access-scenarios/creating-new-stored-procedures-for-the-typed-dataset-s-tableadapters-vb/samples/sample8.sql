ALTER PROCEDURE dbo.Products_Update
(
    @ProductName nvarchar(40),
    @SupplierID int,
    @CategoryID int,
    @QuantityPerUnit nvarchar(20),
    @UnitPrice money,
    @UnitsInStock smallint,
    @UnitsOnOrder smallint,
    @ReorderLevel smallint,
    @Discontinued bit,
    @ProductID int
)
AS
    SET NOCOUNT OFF;
UPDATE [Products] SET [ProductName] = @ProductName, [SupplierID] = @SupplierID, 
    [CategoryID] = @CategoryID, [QuantityPerUnit] = @QuantityPerUnit, 
    [UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock, 
    [UnitsOnOrder] = @UnitsOnOrder, [ReorderLevel] = @ReorderLevel, 
    [Discontinued] = @Discontinued 
WHERE (([ProductID] = @ProductID));
    
SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, 
    UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued 
FROM Products 
WHERE (ProductID = @ProductID)
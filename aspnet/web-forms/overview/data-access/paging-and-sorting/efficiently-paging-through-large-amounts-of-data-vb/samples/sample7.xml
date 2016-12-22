CREATE PROCEDURE dbo.GetProductsPaged
(
    @startRowIndex int,
    @maximumRows int
)
AS
    SELECT     ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit,
               UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued,
               CategoryName, SupplierName
FROM
   (
       SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit,
              UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued,
              (SELECT CategoryName
               FROM Categories
               WHERE Categories.CategoryID = Products.CategoryID) AS CategoryName,
              (SELECT CompanyName
               FROM Suppliers
               WHERE Suppliers.SupplierID = Products.SupplierID) AS SupplierName,
              ROW_NUMBER() OVER (ORDER BY ProductName) AS RowRank
        FROM Products
    ) AS ProductsWithRowNumbers
WHERE RowRank > @startRowIndex AND RowRank <= (@startRowIndex + @maximumRows)
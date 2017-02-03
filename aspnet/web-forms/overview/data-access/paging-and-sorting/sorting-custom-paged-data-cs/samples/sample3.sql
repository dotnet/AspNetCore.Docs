CREATE PROCEDURE dbo.GetProductsPagedAndSorted
(
    @sortExpression nvarchar(100),
    @startRowIndex int,
    @maximumRows int
)
AS
-- Make sure a @sortExpression is specified
IF LEN(@sortExpression) = 0
    SET @sortExpression = 'ProductID'
-- Issue query
DECLARE @sql nvarchar(4000)
SET @sql = 'SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit,
            UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued,
            CategoryName, SupplierName
            FROM (SELECT ProductID, ProductName, p.SupplierID, p.CategoryID,
                    QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder,
                    ReorderLevel, Discontinued,
                  c.CategoryName, s.CompanyName AS SupplierName,
                   ROW_NUMBER() OVER (ORDER BY ' + @sortExpression + ') AS RowRank
            FROM Products AS p
                    INNER JOIN Categories AS c ON
                        c.CategoryID = p.CategoryID
                    INNER JOIN Suppliers AS s ON
                        s.SupplierID = p.SupplierID) AS ProductsWithRowNumbers
            WHERE     RowRank > ' + CONVERT(nvarchar(10), @startRowIndex) +
                ' AND RowRank <= (' + CONVERT(nvarchar(10), @startRowIndex) + ' + '
                + CONVERT(nvarchar(10), @maximumRows) + ')'
-- Execute the SQL query
EXEC sp_executesql @sql
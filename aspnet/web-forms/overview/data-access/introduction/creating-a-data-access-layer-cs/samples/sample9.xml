SELECT     ProductID, ProductName, SupplierID, CategoryID,
QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued,
(SELECT CategoryName FROM Categories
WHERE Categories.CategoryID = Products.CategoryID) as CategoryName,
(SELECT CompanyName FROM Suppliers
WHERE Suppliers.SupplierID = Products.SupplierID) as SupplierName
FROM         Products
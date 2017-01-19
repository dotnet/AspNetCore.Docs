SELECT ProductID, ProductName, Products.SupplierID, Products.CategoryID, 
       QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
       ReorderLevel, Discontinued,
       Categories.CategoryName, 
       Suppliers.CompanyName as SupplierName
FROM Products
    LEFT JOIN Categories ON
        Categories.CategoryID = Products.CategoryID
    LEFT JOIN Suppliers ON
        Suppliers.SupplierID = Products.SupplierID
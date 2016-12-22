SELECT CategoryID, CategoryName, Description,
       (SELECT COUNT(*) FROM Products p WHERE p.CategoryID = c.CategoryID)
            as NumberOfProducts
FROM Categories c
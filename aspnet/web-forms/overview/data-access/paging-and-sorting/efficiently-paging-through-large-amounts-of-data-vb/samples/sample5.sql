SELECT PriceRank, ProductName, UnitPrice
FROM
   (SELECT ProductName, UnitPrice,
       ROW_NUMBER() OVER(ORDER BY UnitPrice DESC) AS PriceRank
    FROM Products
   ) AS ProductsWithRowNumber
WHERE PriceRank BETWEEN 11 AND 20
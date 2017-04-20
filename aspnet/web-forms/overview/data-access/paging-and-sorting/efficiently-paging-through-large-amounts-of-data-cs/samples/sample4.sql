SELECT ProductName, UnitPrice,
       ROW_NUMBER() OVER(ORDER BY UnitPrice DESC) AS PriceRank
FROM Products
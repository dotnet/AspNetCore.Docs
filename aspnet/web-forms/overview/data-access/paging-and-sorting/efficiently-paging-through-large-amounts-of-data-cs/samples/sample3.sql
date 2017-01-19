SELECT columnList,
       ROW_NUMBER() OVER(orderByClause)
FROM TableName
SELECT 
    [Extent1].[BookId] AS [BookId], 
    [Extent1].[Title] AS [Title], 
    [Extent1].[Year] AS [Year], 
    [Extent1].[Price] AS [Price], 
    [Extent1].[Genre] AS [Genre], 
    [Extent1].[AuthorId] AS [AuthorId], 
    [Extent2].[AuthorId] AS [AuthorId1], 
    [Extent2].[Name] AS [Name]
    FROM  [dbo].[Books] AS [Extent1]
    INNER JOIN [dbo].[Authors] AS [Extent2] ON [Extent1].[AuthorId] = [Extent2].[AuthorId]
exec sp_executesql N'SELECT TOP (3) 
[Project1].[StudentID] AS [StudentID], 
[Project1].[LastName] AS [LastName], 
[Project1].[FirstName] AS [FirstName], 
[Project1].[EnrollmentDate] AS [EnrollmentDate]
FROM ( SELECT [Project1].[StudentID] AS [StudentID], [Project1].[LastName] AS [LastName], [Project1].[FirstName] AS [FirstName], [Project1].[EnrollmentDate] AS [EnrollmentDate], row_number() OVER (ORDER BY [Project1].[LastName] ASC) AS [row_number]
FROM ( SELECT 
	[Extent1].[StudentID] AS [StudentID], 
	[Extent1].[LastName] AS [LastName], 
	[Extent1].[FirstName] AS [FirstName], 
	[Extent1].[EnrollmentDate] AS [EnrollmentDate]
	FROM [dbo].[Student] AS [Extent1]
	WHERE (( CAST(CHARINDEX(UPPER(@p__linq__0), UPPER([Extent1].[LastName])) AS int)) > 0) OR (( CAST(CHARINDEX(UPPER(@p__linq__1), UPPER([Extent1].[FirstName])) AS int)) > 0)
)  AS [Project1]
)  AS [Project1]
WHERE [Project1].[row_number] > 0
ORDER BY [Project1].[LastName] ASC',N'@p__linq__0 nvarchar(4000),@p__linq__1 nvarchar(4000)',@p__linq__0=N'Alex',@p__linq__1=N'Alex'
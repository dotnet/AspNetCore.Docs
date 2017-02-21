{SELECT 
[Extent1].[CourseID] AS [CourseID], 
[Extent1].[Title] AS [Title], 
[Extent1].[Credits] AS [Credits], 
[Extent1].[DepartmentID] AS [DepartmentID], 
[Extent2].[DepartmentID] AS [DepartmentID1], 
[Extent2].[Name] AS [Name], 
[Extent2].[Budget] AS [Budget], 
[Extent2].[StartDate] AS [StartDate], 
[Extent2].[PersonID] AS [PersonID], 
[Extent2].[Timestamp] AS [Timestamp]
FROM  [Course] AS [Extent1]
INNER JOIN [Department] AS [Extent2] ON [Extent1].[DepartmentID] = [Extent2].[DepartmentID]
WHERE (@p__linq__0 IS NULL) OR ([Extent1].[DepartmentID] = @p__linq__1)}
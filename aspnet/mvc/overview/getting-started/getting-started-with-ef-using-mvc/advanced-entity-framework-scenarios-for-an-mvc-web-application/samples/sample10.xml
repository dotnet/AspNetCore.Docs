SELECT 
    [Project1].[CourseID] AS [CourseID], 
    [Project1].[Title] AS [Title], 
    [Project1].[Credits] AS [Credits], 
    [Project1].[DepartmentID] AS [DepartmentID], 
    [Project1].[DepartmentID1] AS [DepartmentID1], 
    [Project1].[Name] AS [Name], 
    [Project1].[Budget] AS [Budget], 
    [Project1].[StartDate] AS [StartDate], 
    [Project1].[InstructorID] AS [InstructorID], 
    [Project1].[RowVersion] AS [RowVersion]
    FROM ( SELECT 
        [Extent1].[CourseID] AS [CourseID], 
        [Extent1].[Title] AS [Title], 
        [Extent1].[Credits] AS [Credits], 
        [Extent1].[DepartmentID] AS [DepartmentID], 
        [Extent2].[DepartmentID] AS [DepartmentID1], 
        [Extent2].[Name] AS [Name], 
        [Extent2].[Budget] AS [Budget], 
        [Extent2].[StartDate] AS [StartDate], 
        [Extent2].[InstructorID] AS [InstructorID], 
        [Extent2].[RowVersion] AS [RowVersion]
        FROM  [dbo].[Course] AS [Extent1]
        INNER JOIN [dbo].[Department] AS [Extent2] ON [Extent1].[DepartmentID] = [Extent2].[DepartmentID]
        WHERE @p__linq__0 IS NULL OR [Extent1].[DepartmentID] = @p__linq__1
    )  AS [Project1]
    ORDER BY [Project1].[CourseID] ASC
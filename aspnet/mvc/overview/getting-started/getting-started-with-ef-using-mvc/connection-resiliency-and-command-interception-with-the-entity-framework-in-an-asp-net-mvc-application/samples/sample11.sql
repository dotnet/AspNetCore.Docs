SELECT TOP (3) 
    [Project1].[ID] AS [ID], 
    [Project1].[LastName] AS [LastName], 
    [Project1].[FirstMidName] AS [FirstMidName], 
    [Project1].[EnrollmentDate] AS [EnrollmentDate]
    FROM ( SELECT [Project1].[ID] AS [ID], [Project1].[LastName] AS [LastName], [Project1].[FirstMidName] AS [FirstMidName], [Project1].[EnrollmentDate] AS [EnrollmentDate], row_number() OVER (ORDER BY [Project1].[LastName] ASC) AS [row_number]
        FROM ( SELECT 
            [Extent1].[ID] AS [ID], 
            [Extent1].[LastName] AS [LastName], 
            [Extent1].[FirstMidName] AS [FirstMidName], 
            [Extent1].[EnrollmentDate] AS [EnrollmentDate]
            FROM [dbo].[Student] AS [Extent1]
            WHERE ([Extent1].[LastName] LIKE @p__linq__0 ESCAPE N'~') OR ([Extent1].[FirstMidName] LIKE @p__linq__1 ESCAPE N'~')
        )  AS [Project1]
    )  AS [Project1]
    WHERE [Project1].[row_number] > 0
    ORDER BY [Project1].[LastName] ASC:
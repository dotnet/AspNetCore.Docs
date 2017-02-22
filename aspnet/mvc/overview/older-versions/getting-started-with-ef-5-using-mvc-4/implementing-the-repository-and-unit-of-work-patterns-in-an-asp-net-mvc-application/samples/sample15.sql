SELECT 
'0X0X' AS [C1], 
[Extent1].[PersonID] AS [PersonID], 
[Extent1].[LastName] AS [LastName], 
[Extent1].[FirstName] AS [FirstName], 
[Extent1].[EnrollmentDate] AS [EnrollmentDate]
FROM [dbo].[Person] AS [Extent1]
WHERE [Extent1].[Discriminator] = N'Student'
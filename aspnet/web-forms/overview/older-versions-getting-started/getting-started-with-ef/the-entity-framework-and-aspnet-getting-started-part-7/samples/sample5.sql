CREATE PROCEDURE [dbo].[GetCourses]
            AS
            SELECT CourseID, Title, Credits, DepartmentID FROM dbo.Course
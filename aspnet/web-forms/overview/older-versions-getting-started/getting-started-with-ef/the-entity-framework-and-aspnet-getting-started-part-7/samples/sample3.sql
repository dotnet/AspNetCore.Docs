CREATE PROCEDURE [dbo].[UpdateStudent]
	@PersonID int,
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@EnrollmentDate datetime
	AS
	UPDATE Person SET LastName=@LastName, 
			FirstName=@FirstName,
			EnrollmentDate=@EnrollmentDate
	WHERE PersonID=@PersonID;
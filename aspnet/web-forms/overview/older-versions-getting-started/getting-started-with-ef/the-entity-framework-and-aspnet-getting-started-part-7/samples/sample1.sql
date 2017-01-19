CREATE PROCEDURE [dbo].[InsertStudent]
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@EnrollmentDate datetime
	AS
	INSERT INTO dbo.Person (LastName, 
				FirstName, 
				EnrollmentDate)
	VALUES (@LastName, 
		@FirstName, 
		@EnrollmentDate);
	SELECT SCOPE_IDENTITY() as NewPersonID;
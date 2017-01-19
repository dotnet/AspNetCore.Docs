CREATE PROCEDURE [dbo].[InsertInstructor]
		@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@HireDate datetime
	AS
	INSERT INTO dbo.Person (LastName, 
				FirstName, 
				HireDate)
	VALUES (@LastName, 
		@FirstName, 
		@HireDate);
	SELECT SCOPE_IDENTITY() as NewPersonID;
CREATE PROCEDURE [dbo].[UpdateInstructor]
	@PersonID int,
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@HireDate datetime
	AS
	UPDATE Person SET LastName=@LastName, 
			FirstName=@FirstName,
			HireDate=@HireDate
	WHERE PersonID=@PersonID;
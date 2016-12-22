ALTER PROCEDURE [dbo].[UpdateOfficeAssignment]
	@InstructorID int,
	@Location nvarchar(50),
	@OrigTimestamp timestamp
	AS
	UPDATE OfficeAssignment SET Location=@Location 
	WHERE InstructorID=@InstructorID AND [Timestamp]=@OrigTimestamp;
	IF @@ROWCOUNT > 0
	BEGIN
		SELECT [Timestamp] FROM OfficeAssignment 
			WHERE InstructorID=@InstructorID;
	END
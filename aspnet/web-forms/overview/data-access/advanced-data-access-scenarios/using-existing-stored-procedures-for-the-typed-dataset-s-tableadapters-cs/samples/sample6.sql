CREATE PROCEDURE dbo.Categories_Delete
(
    @CategoryID int
)
AS
BEGIN TRY
  BEGIN TRANSACTION -- Start the transaction
  -- First, delete the associated products...
  DELETE FROM Products
  WHERE CategoryID = @CategoryID
  -- Now delete the category
  DELETE FROM Categories
  WHERE CategoryID = @CategoryID
  -- If we reach here, success!
  COMMIT TRANSACTION
END TRY
BEGIN CATCH 
  -- Whoops, there was an error
  ROLLBACK TRANSACTION
  -- Raise an error with the 
  -- details of the exception   
  DECLARE @ErrMsg nvarchar(4000),
          @ErrSeverity int 
  SELECT @ErrMsg = ERROR_MESSAGE(), 
         @ErrSeverity = ERROR_SEVERITY() 
 
  RAISERROR(@ErrMsg, @ErrSeverity, 1) 
END CATCH
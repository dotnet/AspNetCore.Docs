BEGIN TRY
  BEGIN TRANSACTION -- Start the transaction
  ... Perform the SQL statements that makeup the transaction ...
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
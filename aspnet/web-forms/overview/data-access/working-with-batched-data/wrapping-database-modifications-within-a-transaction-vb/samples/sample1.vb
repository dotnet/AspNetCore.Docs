' Create the SqlTransaction object
Dim myTransaction As SqlTransaction = SqlConnectionObject.BeginTransaction();
Try
    '
    ' ... Perform the database transaction�s data modification statements...
    '
    ' If we reach here, no errors, so commit the transaction
    myTransaction.Commit()
Catch
    ' If we reach here, there was an error, so rollback the transaction
    myTransaction.Rollback()
    Throw
End Try
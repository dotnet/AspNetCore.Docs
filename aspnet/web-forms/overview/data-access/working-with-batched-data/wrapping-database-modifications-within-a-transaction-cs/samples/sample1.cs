// Create the SqlTransaction object
SqlTransaction myTransaction = SqlConnectionObject.BeginTransaction();
try
{
    /*
     * ... Perform the database transaction�s data modification statements...
     */
    // If we reach here, no errors, so commit the transaction
    myTransaction.Commit();
}
catch
{
    // If we reach here, there was an error, so rollback the transaction
    myTransaction.Rollback();
    throw;
}
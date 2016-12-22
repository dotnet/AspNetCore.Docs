public int UpdateWithTransaction(Northwind.ProductsDataTable dataTable)
{
    this.BeginTransaction();
    try
    {
        // Perform the update on the DataTable
        int returnValue = this.Adapter.Update(dataTable);
        // If we reach here, no errors, so commit the transaction
        this.CommitTransaction();
        return returnValue;
    }
    catch
    {
        // If we reach here, there was an error, so rollback the transaction
        this.RollbackTransaction();
        throw;
    }
}
public void DeleteProductsWithTransaction
    (System.Collections.Generic.List<int> productIDs)
{
    // Start the transaction
    Adapter.BeginTransaction();
    try
    {
        // Delete each product specified in the list
        foreach (int productID in productIDs)
        {
            Adapter.Delete(productID);
        }
        // Commit the transaction
        Adapter.CommitTransaction();
    }
    catch
    {
        // There was an error - rollback the transaction
        Adapter.RollbackTransaction();
        throw;
    }
}
[System.ComponentModel.DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
public bool UpdateProduct(string productName, decimal? unitPrice, int productID)
{
    bool result = API.UpdateProduct(productName, unitPrice, productID);
    // Invalidate the cache
    InvalidateCache();
    return result;
}
public void InvalidateCache()
{
    // Remove the cache dependency
    HttpRuntime.Cache.Remove(MasterCacheKeyArray[0]);
}
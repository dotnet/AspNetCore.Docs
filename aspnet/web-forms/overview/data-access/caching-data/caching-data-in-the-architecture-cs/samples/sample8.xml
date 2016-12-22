[System.ComponentModel.DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
public bool UpdateProduct(string productName, decimal? unitPrice, int productID)
{
    bool result = API.UpdateProduct(productName, unitPrice, productID);
    // TODO: Invalidate the cache
    return result;
}
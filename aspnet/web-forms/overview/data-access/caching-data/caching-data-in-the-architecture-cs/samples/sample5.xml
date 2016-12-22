[System.ComponentModel.DataObject]
public class ProductsCL
{
    private ProductsBLL _productsAPI = null;
    protected ProductsBLL API
    {
        get
        {
            if (_productsAPI == null)
                _productsAPI = new ProductsBLL();
            return _productsAPI;
        }
    }
    
   [System.ComponentModel.DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public Northwind.ProductsDataTable GetProducts()
    {
        const string rawKey = "Products";
        // See if the item is in the cache
        Northwind.ProductsDataTable products = _
            GetCacheItem(rawKey) as Northwind.ProductsDataTable;
        if (products == null)
        {
            // Item not found in cache - retrieve it and insert it into the cache
            products = API.GetProducts();
            AddCacheItem(rawKey, products);
        }
        return products;
    }
    
    [System.ComponentModel.DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public Northwind.ProductsDataTable GetProductsByCategoryID(int categoryID)
    {
        if (categoryID < 0)
            return GetProducts();
        else
        {
            string rawKey = string.Concat("ProductsByCategory-", categoryID);
            // See if the item is in the cache
            Northwind.ProductsDataTable products = _
                GetCacheItem(rawKey) as Northwind.ProductsDataTable;
            if (products == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                products = API.GetProductsByCategoryID(categoryID);
                AddCacheItem(rawKey, products);
            }
            return products;
        }
    }
}
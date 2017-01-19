public Northwind.ProductsDataTable GetProductsByCategoryID(int categoryID)
{
    if (categoryID < 0)
        return GetProducts();
    else
        return Adapter.GetProductsByCategoryID(categoryID);
}
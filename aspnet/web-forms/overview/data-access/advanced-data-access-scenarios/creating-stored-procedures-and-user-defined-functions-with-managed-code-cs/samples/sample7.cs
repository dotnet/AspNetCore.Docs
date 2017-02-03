[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
public NorthwindWithSprocs.ProductsDataTable GetDiscontinuedProducts()
{
    return Adapter.GetDiscontinuedProducts();
}
[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
public NorthwindWithSprocs.ProductsDataTable 
    GetProductsWithPriceLessThan(decimal priceLessThan)
{
    return Adapter.GetProductsWithPriceLessThan(priceLessThan);
}
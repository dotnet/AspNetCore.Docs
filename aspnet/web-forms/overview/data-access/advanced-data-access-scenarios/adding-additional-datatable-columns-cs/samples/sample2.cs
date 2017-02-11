[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
public NorthwindWithSprocs.ProductsDataTable GetProductsWithPriceQuartile()
{
    return Adapter.GetProductsWithPriceQuartile();
}
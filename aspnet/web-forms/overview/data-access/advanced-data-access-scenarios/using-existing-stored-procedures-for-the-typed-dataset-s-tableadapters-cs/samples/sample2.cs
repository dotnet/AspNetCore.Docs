[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
public NorthwindWithSprocs.ProductsDataTable GetProductByCategoryID(int categoryID)
{
    return Adapter.GetProductsByCategoryID(categoryID);
}
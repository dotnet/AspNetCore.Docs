[System.ComponentModel.DataObjectMethodAttribute
(System.ComponentModel.DataObjectMethodType.Delete, true)]
public bool DeleteProduct
    (int original_productID, string original_productName,
    int? original_supplierID, int? original_categoryID,
    string original_quantityPerUnit, decimal? original_unitPrice,
    short? original_unitsInStock, short? original_unitsOnOrder,
    short? original_reorderLevel, bool original_discontinued)
{
    int rowsAffected = Adapter.Delete(original_productID,
                                      original_productName,
                                      original_supplierID,
                                      original_categoryID,
                                      original_quantityPerUnit,
                                      original_unitPrice,
                                      original_unitsInStock,
                                      original_unitsOnOrder,
                                      original_reorderLevel,
                                      original_discontinued);
    // Return true if precisely one row was deleted, otherwise false
    return rowsAffected == 1;
}
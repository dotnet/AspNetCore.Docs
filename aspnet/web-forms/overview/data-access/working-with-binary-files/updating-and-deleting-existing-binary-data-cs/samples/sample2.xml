[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Delete, true)]
public bool DeleteCategory(int categoryID)
{
    int rowsAffected = Adapter.Delete(categoryID);
    // Return true if precisely one row was deleted, otherwise false
    return rowsAffected == 1;
}
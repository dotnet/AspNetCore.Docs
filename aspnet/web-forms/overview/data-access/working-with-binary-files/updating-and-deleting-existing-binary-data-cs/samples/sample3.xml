[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Update, false)]
public bool UpdateCategory(string categoryName, string description, 
    string brochurePath, byte[] picture, int categoryID)
{
    // If no picture is specified, use other overload
    if (picture == null)
        return UpdateCategory(categoryName, description, brochurePath, categoryID);
    // Update picture, as well
    int rowsAffected = Adapter.UpdateWithPicture
        (categoryName, description, brochurePath, picture, categoryID);
    // Return true if precisely one row was updated, otherwise false
    return rowsAffected == 1;
}
[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Update, true)]
public bool UpdateCategory(string categoryName, string description, 
    string brochurePath, int categoryID)
{
    int rowsAffected = Adapter.Update
        (categoryName, description, brochurePath, categoryID);
    // Return true if precisely one row was updated, otherwise false
    return rowsAffected == 1;
}
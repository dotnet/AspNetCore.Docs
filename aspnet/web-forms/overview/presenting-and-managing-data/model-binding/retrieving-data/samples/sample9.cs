// The id parameter name should match the DataKeyNames value set on the control
public void studentsGrid_UpdateItem(int id)
{
    ContosoUniversityModelBinding.Models.Student item = null;
    // Load the item here, e.g. item = MyDataLayer.Find(id);
    if (item == null)
    {
        // The item wasn't found
        ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
        return;
    }
    TryUpdateModel(item);
    if (ModelState.IsValid)
    {
        // Save changes here, e.g. MyDataLayer.SaveChanges();

    }
}
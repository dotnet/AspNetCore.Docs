if (databaseEntry == null)
{
    ModelState.AddModelError(string.Empty,
        "Unable to save changes. The department was deleted by another user.");
}
else
{
    var databaseValues = (Department)databaseEntry.ToObject();
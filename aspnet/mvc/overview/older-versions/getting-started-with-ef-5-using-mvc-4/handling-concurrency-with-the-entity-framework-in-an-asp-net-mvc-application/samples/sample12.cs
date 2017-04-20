public ActionResult Delete(int id, bool? concurrencyError)
{
    Department department = db.Departments.Find(id);

    if (concurrencyError.GetValueOrDefault())
    {
        if (department == null)
        {
            ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                + "was deleted by another user after you got the original values. "
                + "Click the Back to List hyperlink.";
        }
        else
        {
            ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                + "was modified by another user after you got the original values. "
                + "The delete operation was canceled and the current values in the "
                + "database have been displayed. If you still want to delete this "
                + "record, click the Delete button again. Otherwise "
                + "click the Back to List hyperlink.";
        }
    }

    return View(department);
}
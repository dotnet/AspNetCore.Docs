public async Task<ActionResult> Delete(int? id, bool? concurrencyError)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Department department = await db.Departments.FindAsync(id);
    if (department == null)
    {
        if (concurrencyError.GetValueOrDefault())
        {
            return RedirectToAction("Index");
        }
        return HttpNotFound();
    }

    if (concurrencyError.GetValueOrDefault())
    {
        ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
            + "was modified by another user after you got the original values. "
            + "The delete operation was canceled and the current values in the "
            + "database have been displayed. If you still want to delete this "
            + "record, click the Delete button again. Otherwise "
            + "click the Back to List hyperlink.";
    }

    return View(department);
}
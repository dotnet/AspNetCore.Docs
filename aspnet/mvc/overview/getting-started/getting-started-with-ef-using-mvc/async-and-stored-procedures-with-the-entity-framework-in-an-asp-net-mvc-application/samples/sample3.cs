public async Task<ActionResult> Create(Department department)
{
    if (ModelState.IsValid)
    {
        db.Departments.Add(department);
    await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
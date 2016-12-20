public async Task<ActionResult> Details(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }

    // Commenting out original code to show how to use a raw SQL query.
    //Department department = await db.Departments.FindAsync(id);

    // Create and execute raw SQL query.
    string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
    Department department = await db.Departments.SqlQuery(query, id).SingleOrDefaultAsync();
    
    if (department == null)
    {
        return HttpNotFound();
    }
    return View(department);
}
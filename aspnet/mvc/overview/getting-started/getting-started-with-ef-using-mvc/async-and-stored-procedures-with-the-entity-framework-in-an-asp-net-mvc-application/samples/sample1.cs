public async Task<ActionResult> Index()
{
    var departments = db.Departments.Include(d => d.Administrator);
    return View(await departments.ToListAsync());
}
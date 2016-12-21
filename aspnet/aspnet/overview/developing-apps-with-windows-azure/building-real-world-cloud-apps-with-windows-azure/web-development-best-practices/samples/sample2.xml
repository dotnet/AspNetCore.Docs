public async Task<ActionResult> Index()
{
    string currentUser = User.Identity.Name;
    var result = await fixItRepository.FindOpenTasksByOwnerAsync(currentUser);

    return View(result);
}
[Authorize(Roles="Administrator")]
public ActionResult Admin()
{
    return View();
}
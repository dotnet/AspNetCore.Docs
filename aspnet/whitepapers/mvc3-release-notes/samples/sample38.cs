[ValidateInput(true, Exclude="Body, Summary")]
public ActionResult About() {
	return View();
}
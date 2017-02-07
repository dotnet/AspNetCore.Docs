public ViewResult Create() {
	return View(new UserModel());
}

[HttpPost]
public ViewResult Create(UserModel um) {

	if (!TryUpdateModel(um)) {
		ViewBag.updateError = "Create Failure";
		return View(um);
	}

	// ToDo: add persistent to DB.
	_usrs.Create(um);
	return View("Details", um);
}
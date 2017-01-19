public ViewResult Edit(string id) {
    return View(_usrs.GetUser(id));
}

[HttpPost]
public ViewResult Edit(UserModel um) {

    if (!TryUpdateModel(um)) {
        ViewBag.updateError = "Update Failure";
        return View(um);
    }

    // ToDo: add persistent to DB.
    _usrs.Update(um);
    return View("Details", um);
}
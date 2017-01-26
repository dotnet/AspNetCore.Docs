public ViewResult Delete(string id) {
	return View(_usrs.GetUser(id));
}

[HttpPost]
public RedirectToRouteResult Delete(string id, FormCollection collection) {
	_usrs.Remove(id);
	return RedirectToAction("Index");
}
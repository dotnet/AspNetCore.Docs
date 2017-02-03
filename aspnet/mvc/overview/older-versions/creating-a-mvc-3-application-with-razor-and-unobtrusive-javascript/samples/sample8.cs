public ViewResult Details(string id) {
    return View(_usrs.GetUser(id));
}
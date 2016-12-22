//
// GET: /Dinners/Edit/5

[Authorize]
public ActionResult Edit(int id) {

    Dinner dinner = dinnerRepository.GetDinner(id);

    ViewData["Countries"] = new SelectList(PhoneValidator.AllCountries, dinner.Country);

    return View(dinner);
}
//
// POST: /Dinners/Edit/5

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Edit(int id, FormCollection collection) {

    Dinner dinner = dinnerRepository.GetDinner(id);

    try {
    
        UpdateModel(dinner);

        dinnerRepository.Save();

        return RedirectToAction("Details", new { id=dinner.DinnerID });
    }
    catch {
    
        ModelState.AddModelErrors(dinner.GetRuleViolations());

        ViewData["countries"] = new SelectList(PhoneValidator.AllCountries, dinner.Country);

        return View(dinner);
    }
}
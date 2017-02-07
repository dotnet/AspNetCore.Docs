//
// POST: /Dinners/Edit/2

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Edit(int id, FormCollection formValues) {

    Dinner dinner = dinnerRepository.GetDinner(id);

    UpdateModel(dinner);

    dinnerRepository.Save();

    return RedirectToAction("Details", new { id = dinner.DinnerID });
}
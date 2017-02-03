//
// POST: /Dinners/Create

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create() {

    Dinner dinner = new Dinner();

    try {
    
        UpdateModel(dinner);

        dinnerRepository.Add(dinner);
        dinnerRepository.Save();

        return RedirectToAction("Details", new {id=dinner.DinnerID});
    }
    catch {
    
        ModelState.AddRuleViolations(dinner.GetRuleViolations());

        return View(dinner);
    }
}
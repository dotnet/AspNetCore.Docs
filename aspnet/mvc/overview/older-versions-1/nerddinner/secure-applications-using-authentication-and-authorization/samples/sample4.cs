//
// POST: /Dinners/Create

[AcceptVerbs(HttpVerbs.Post), Authorize]
public ActionResult Create(Dinner dinner) {

    if (ModelState.IsValid) {
    
        try {
            dinner.HostedBy = User.Identity.Name;

            RSVP rsvp = new RSVP();
            rsvp.AttendeeName = User.Identity.Name;
            dinner.RSVPs.Add(rsvp);

            dinnerRepository.Add(dinner);
            dinnerRepository.Save();

            return RedirectToAction("Details", new { id=dinner.DinnerID });
        }
        catch {
            ModelState.AddModelErrors(dinner.GetRuleViolations());
        }
    }

    return View(new DinnerFormViewModel(dinner));
}
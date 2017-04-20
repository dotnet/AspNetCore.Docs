public class RSVPController : Controller {

    DinnerRepository dinnerRepository = new DinnerRepository();

    //
    // AJAX: /Dinners/RSVPForEvent/1

    [Authorize, AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Register(int id) {

        Dinner dinner = dinnerRepository.GetDinner(id);

        if (!dinner.IsUserRegistered(User.Identity.Name)) {
        
            RSVP rsvp = new RSVP();
            rsvp.AttendeeName = User.Identity.Name;

            dinner.RSVPs.Add(rsvp);
            dinnerRepository.Save();
        }

        return Content("Thanks - we'll see you there!");
    }
}
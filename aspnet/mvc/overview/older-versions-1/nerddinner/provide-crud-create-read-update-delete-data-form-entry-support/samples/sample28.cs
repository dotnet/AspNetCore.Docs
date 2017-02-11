//
// HTTP GET: /Dinners/Delete/1

public ActionResult Delete(int id) {

    Dinner dinner = dinnerRepository.GetDinner(id);

    if (dinner == null)
         return View("NotFound");
    else
        return View(dinner);
}
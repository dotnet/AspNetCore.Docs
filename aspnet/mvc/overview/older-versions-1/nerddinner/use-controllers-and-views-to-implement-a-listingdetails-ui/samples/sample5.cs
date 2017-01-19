//
    // GET: /Dinners/

    public ActionResult Index() {
    
        var dinners = dinnerRepository.FindUpcomingDinners().ToList();
        
        return View("Index", dinners);
    }
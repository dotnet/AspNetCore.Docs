//
// GET: /Dinners/
//      /Dinners/Page/2

public ActionResult Index(int? page) {

    const int pageSize = 10;

    var upcomingDinners = dinnerRepository.FindUpcomingDinners();
    
    var paginatedDinners = upcomingDinners.Skip((page ?? 0) * pageSize)
                                          .Take(pageSize)
                                          .ToList();

    return View(paginatedDinners);
}
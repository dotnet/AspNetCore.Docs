//
// GET: /Dinners/
//      /Dinners/Page/2

public ActionResult Index(int? page) {

    const int pageSize = 10;

    var upcomingDinners = dinnerRepository.FindUpcomingDinners();
    var paginatedDinners = new PaginatedList<Dinner>(upcomingDinners, page ?? 0, pageSize);

    return View(paginatedDinners);
}
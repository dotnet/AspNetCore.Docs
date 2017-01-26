[AsyncTimeout(2500)]
[HandleError(ExceptionType = typeof(TaskCanceledException), View = "TimedOut")]
public async Task<ActionResult> Index(string city,
    CancellationToken cancellationToken) {
    var newsService = new NewsService();
    var sportsService = new SportsService();
   
    return View("Common",
        new PortalViewModel {
        NewsHeadlines = await newsService.GetHeadlinesAsync(cancellationToken),
        SportsScores = await sportsService.GetScoresAsync(cancellationToken)
    });
}
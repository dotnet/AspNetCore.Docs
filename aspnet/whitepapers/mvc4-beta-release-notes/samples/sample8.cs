public async Task<ActionResult> Index(string city) {
    var newsService = new NewsService();
    var sportsService = new SportsService();
    
    return View("Common",
        new PortalViewModel {
        NewsHeadlines = await newsService.GetHeadlinesAsync(),
        SportsScores = await sportsService.GetScoresAsync()
    });
}
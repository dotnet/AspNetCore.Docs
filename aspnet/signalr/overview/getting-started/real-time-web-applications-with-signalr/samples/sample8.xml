public async Task<IHttpActionResult> Post(TriviaAnswer answer)
{
    if (!ModelState.IsValid)
    {
         return this.BadRequest(this.ModelState);
    }

    answer.UserId = User.Identity.Name;

    var isCorrect = await this.StoreAsync(answer);

    var statisticsService = new StatisticsService(this.db);
    await statisticsService.NotifyUpdates();

    return this.Ok<bool>(isCorrect);
}
// GET api/Trivia
[ResponseType(typeof(TriviaQuestion))]
public async Task<IHttpActionResult> Get()
{
    var userId = User.Identity.Name;

    TriviaQuestion nextQuestion = await this.NextQuestionAsync(userId);

    if (nextQuestion == null)
    {
        return this.NotFound();
    }

    return this.Ok(nextQuestion);
}
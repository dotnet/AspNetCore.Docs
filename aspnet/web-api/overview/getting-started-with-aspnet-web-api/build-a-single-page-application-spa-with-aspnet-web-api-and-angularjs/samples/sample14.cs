// POST api/Trivia
[ResponseType(typeof(TriviaAnswer))]
public async Task<IHttpActionResult> Post(TriviaAnswer answer)
{
    if (!ModelState.IsValid)
    {
        return this.BadRequest(this.ModelState);
    }

    answer.UserId = User.Identity.Name;

    var isCorrect = await this.StoreAsync(answer);
    return this.Ok<bool>(isCorrect);
}
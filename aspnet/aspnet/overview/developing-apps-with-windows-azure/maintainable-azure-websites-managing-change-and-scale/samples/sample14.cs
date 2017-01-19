private async Task<bool> StoreAsync(TriviaAnswer answer)
{
    this.db.TriviaAnswers.Add(answer);

    await this.db.SaveChangesAsync();
    var selectedOption = await this.db.TriviaOptions.FirstOrDefaultAsync(o => MatchesOption(answer, o));

    return selectedOption.IsCorrect;
}

private static bool MatchesOption(TriviaAnswer answer, TriviaOption o)
{
    return o.Id == answer.OptionId
            && o.QuestionId == answer.QuestionId;
}
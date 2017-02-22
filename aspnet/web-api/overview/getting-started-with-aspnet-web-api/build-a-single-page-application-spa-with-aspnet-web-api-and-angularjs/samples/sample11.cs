private async Task<TriviaQuestion> NextQuestionAsync(string userId)
{
    var lastQuestionId = await this.db.TriviaAnswers
        .Where(a => a.UserId == userId)
        .GroupBy(a => a.QuestionId)
        .Select(g => new { QuestionId = g.Key, Count = g.Count() })
        .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
        .Select(q => q.QuestionId)
        .FirstOrDefaultAsync();

    var questionsCount = await this.db.TriviaQuestions.CountAsync();

    var nextQuestionId = (lastQuestionId % questionsCount) + 1;
    return await this.db.TriviaQuestions.FindAsync(CancellationToken.None, nextQuestionId);
}
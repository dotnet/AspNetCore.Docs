public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
{
    var challenge = new AuthenticationHeaderValue("Basic");
    context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
    return Task.FromResult(0);
}
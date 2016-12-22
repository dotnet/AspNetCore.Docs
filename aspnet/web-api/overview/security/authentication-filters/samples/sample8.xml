public class AddChallengeOnUnauthorizedResult : IHttpActionResult
{
    public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
    {
        Challenge = challenge;
        InnerResult = innerResult;
    }

    public AuthenticationHeaderValue Challenge { get; private set; }

    public IHttpActionResult InnerResult { get; private set; }

    public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await InnerResult.ExecuteAsync(cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // Only add one challenge per authentication scheme.
            if (!response.Headers.WwwAuthenticate.Any((h) => h.Scheme == Challenge.Scheme))
            {
                response.Headers.WwwAuthenticate.Add(Challenge);
            }
        }

        return response;
    }
}
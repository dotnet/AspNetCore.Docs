public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
{
    // 1. Look for credentials in the request.
    HttpRequestMessage request = context.Request;
    AuthenticationHeaderValue authorization = request.Headers.Authorization;

    // 2. If there are no credentials, do nothing.
    if (authorization == null)
    {
        return;
    }

    // 3. If there are credentials but the filter does not recognize the 
    //    authentication scheme, do nothing.
    if (authorization.Scheme != "Basic")
    {
        return;
    }

    // 4. If there are credentials that the filter understands, try to validate them.
    // 5. If the credentials are bad, set the error result.
    if (String.IsNullOrEmpty(authorization.Parameter))
    {
        context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
        return;
    }

    Tuple<string, string> userNameAndPasword = ExtractUserNameAndPassword(authorization.Parameter);
    if (userNameAndPasword == null)
    {
        context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
    }

    string userName = userNameAndPasword.Item1;
    string password = userNameAndPasword.Item2;

    IPrincipal principal = await AuthenticateAsync(userName, password, cancellationToken);
    if (principal == null)
    {
        context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
    }

    // 6. If the credentials are valid, set principal.
    else
    {
        context.Principal = principal;
    }

}
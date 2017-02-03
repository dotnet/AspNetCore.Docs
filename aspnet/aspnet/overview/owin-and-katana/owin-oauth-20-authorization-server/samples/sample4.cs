private Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
{
    if (context.ClientId == Clients.Client1.Id)
    {
        context.Validated(Clients.Client1.RedirectUrl);
    }
    else if (context.ClientId == Clients.Client2.Id)
    {
        context.Validated(Clients.Client2.RedirectUrl);
    }
    return Task.FromResult(0);
}

private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
{
    string clientId;
    string clientSecret;
    if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
        context.TryGetFormCredentials(out clientId, out clientSecret))
    {
        if (clientId == Clients.Client1.Id && clientSecret == Clients.Client1.Secret)
        {
            context.Validated();
        }
        else if (clientId == Clients.Client2.Id && clientSecret == Clients.Client2.Secret)
        {
            context.Validated();
        }
    }
    return Task.FromResult(0);
}
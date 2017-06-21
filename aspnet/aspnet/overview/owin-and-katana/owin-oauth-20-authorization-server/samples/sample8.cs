private Task GrantClientCredetails(OAuthGrantClientCredentialsContext context)
{
    var identity = new ClaimsIdentity(new GenericIdentity(
        context.ClientId, OAuthDefaults.AuthenticationType), 
        context.Scope.Select(x => new Claim("urn:oauth:scope", x))
        );

    context.Validated(identity);

    return Task.FromResult(0);
}
private Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
 {
     var identity = new ClaimsIdentity(new GenericIdentity(
        context.UserName, OAuthDefaults.AuthenticationType), 
        context.Scope.Select(x => new Claim("urn:oauth:scope", x))
        );

     context.Validated(identity);

     return Task.FromResult(0);
 }
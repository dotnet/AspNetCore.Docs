private readonly ConcurrentDictionary<string, string> _authenticationCodes =
     new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

 private void CreateAuthenticationCode(AuthenticationTokenCreateContext context)
 {
     context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
     _authenticationCodes[context.Token] = context.SerializeTicket();
 }

 private void ReceiveAuthenticationCode(AuthenticationTokenReceiveContext context)
 {
     string value;
     if (_authenticationCodes.TryRemove(context.Token, out value))
     {
         context.DeserializeTicket(value);
     }
 }
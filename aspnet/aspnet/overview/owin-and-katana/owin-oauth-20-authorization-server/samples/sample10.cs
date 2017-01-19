private void CreateRefreshToken(AuthenticationTokenCreateContext context)
 {
     context.SetToken(context.SerializeTicket());
 }

 private void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
 {
     context.DeserializeTicket(context.Token);
 }
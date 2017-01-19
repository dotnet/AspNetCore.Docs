var confirmationToken = Request.QueryString["ConfirmationToken"];
if(WebSecurity.ConfirmAccount(confirmationToken)) {
      //...
}
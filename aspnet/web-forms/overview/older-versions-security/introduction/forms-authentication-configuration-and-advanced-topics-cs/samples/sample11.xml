<%@ Application Language="C#" %>

<%@ Import Namespace="System.Security.Principal" %>

<%@ Import Namespace="System.Threading" %>

<script runat="server">

  void Application_OnPostAuthenticateRequest(object sender, EventArgs e)

  {

  // Get a reference to the current User

  IPrincipal usr = HttpContext.Current.User;

  // If we are dealing with an authenticated forms authentication request

  if (usr.Identity.IsAuthenticated && usr.Identity.AuthenticationType == "Forms")

  {

  FormsIdentity fIdent = usr.Identity as FormsIdentity;

  // Create a CustomIdentity based on the FormsAuthenticationTicket  

  CustomIdentity ci = new CustomIdentity(fIdent.Ticket);

  // Create the CustomPrincipal

  CustomPrincipal p = new CustomPrincipal(ci);

  // Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal

  HttpContext.Current.User = p;

  Thread.CurrentPrincipal = p;

  }

  }

</script>
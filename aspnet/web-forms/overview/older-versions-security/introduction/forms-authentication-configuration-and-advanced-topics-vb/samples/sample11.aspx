<%@ Application Language="VB" %>

<%@ Import Namespace="System.Security.Principal" %>

<%@ Import Namespace="System.Threading" %>

<script runat="server">

 Sub Application_OnPostAuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

 ' Get a reference to the current User

 Dim usr As IPrincipal = HttpContext.Current.User

 ' If we are dealing with an authenticated forms authentication request

 If usr.Identity.IsAuthenticated AndAlso usr.Identity.AuthenticationType = "Forms" Then

 Dim fIdent As FormsIdentity = CType(usr.Identity, FormsIdentity)

 ' Create a CustomIdentity based on the FormsAuthenticationTicket

 Dim ci As New CustomIdentity(fIdent.Ticket)

 ' Create the CustomPrincipal

 Dim p As New CustomPrincipal(ci)

 ' Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal

 HttpContext.Current.User = p

 Thread.CurrentPrincipal = p

 End If

 End Sub

</script>
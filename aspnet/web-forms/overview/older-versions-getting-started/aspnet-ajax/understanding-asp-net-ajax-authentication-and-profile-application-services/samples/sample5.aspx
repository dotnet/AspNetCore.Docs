<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
 <title>Login Example</title>
 <script type="text/javascript">
 function Login()
 {
 var userTextbox = $get("txtUser");
 var passTextbox = $get("txtPassword");
 Sys.Services.AuthenticationService.login(userTextbox.value, 
 passTextbox.value, false, null, null, LoginServiceCompleted, 
 LoginServiceFailed, "Context Info");
 }
 function Logout()
 {
 Sys.Services.AuthenticationService.logout(null, LogoutServiceCompleted, 
 LoginServiceFailed, "Context Info");
 }
 function LoginServiceFailed(error, userContext, methodName)
 {
 alert('There was an error with the authentication service:\n\n' + error);
 }
 function LoginServiceCompleted(validCredentials, userContext, methodName)
 {
 if (validCredentials)
 {
 alert('Great! You successfully logged in.');
 }
 else
 {
 alert('Oops! You gave us bad credentials!');
 }
 }
 function LogoutServiceCompleted(result, userContext, methodName)
 {
 alert('You have been logged out from the web site.');
 }
 </script>
 </head>
 <body>
 <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" 
 EnableScriptLocalization="true">
 </asp:ScriptManager>
 <div>
 <asp:TextBox ID="txtUser" runat="Server"></asp:TextBox>
 <br />
 <asp:TextBox ID="txtPassword" runat="Server" TextMode="Password"/>
 <br />
 <asp:Button Text="Log in" ID="btnLogin" runat="server" 
 OnClientClick="Login(); return false;" />
 </div>
 </form>
 </body>
</html>
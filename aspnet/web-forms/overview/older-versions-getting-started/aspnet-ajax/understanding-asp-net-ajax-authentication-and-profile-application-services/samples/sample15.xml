function Login()
{
 var userTextbox = $get("txtUser");
 var passTextbox = $get("txtPassword");
 Sys.Services.AuthenticationService.set_path("./AuthService.asmx");
 Sys.Services.AuthenticationService.login(userTextbox.value, passTextbox.value, false, null, null, LoginServiceCompleted, LoginServiceFailed, "Context Info");
}
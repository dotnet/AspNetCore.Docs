function Page_Load()
{
 if (Sys.Services.AuthenticationService.get_isLoggedIn())
 {
 Sys.Services.ProfileService.load();
 }
}
function ProfileLoaded(numPropsLoaded, userContext, methodName)
{
 document.documentElement.style.backgroundColor = Sys.Services.ProfileService.properties.BackgroundColor;
}
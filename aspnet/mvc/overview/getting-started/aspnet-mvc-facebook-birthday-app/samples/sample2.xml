public class HomeController : Controller
{
   [FacebookAuthorize("email", "user_photos")]
   public async Task<ActionResult> Index(FacebookContext context)
   {
      if (ModelState.IsValid)
      {
         var user = await context.Client.GetCurrentUserAsync<MyAppUser>();
         return View(user);
      }

      return View("Error");
   }

   // This action will handle the redirects from FacebookAuthorizeFilter when
   // the app doesn't have all the required permissions specified in the FacebookAuthorizeAttribute.
   // The path to this action is defined under appSettings (in Web.config) with the key 
   // 'Facebook:AuthorizationRedirectPath'.
   public ActionResult Permissions(FacebookRedirectContext context)
   {
      if (ModelState.IsValid)
      {
         return View(context);
      }

      return View("Error");
   }
}
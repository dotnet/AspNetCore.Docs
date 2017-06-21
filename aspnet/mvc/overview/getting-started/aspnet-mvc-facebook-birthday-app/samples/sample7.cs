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
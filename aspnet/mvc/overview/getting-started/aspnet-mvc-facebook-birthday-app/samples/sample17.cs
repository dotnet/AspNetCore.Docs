public class HomeController : Controller
{
   [FacebookAuthorize("friends_birthday", "user_friends")]
   public async Task<ActionResult> Index(FacebookContext context)
   {
      ViewBag.AppUrl = GlobalFacebookConfiguration.Configuration.AppUrl;
      if (ModelState.IsValid)
      {
         var user = await context.Client.GetCurrentUserAsync<MyAppUser>();
         var friendsWithUpcomingBirthdays = user.Friends.Data.OrderBy(friend =>
         {
            try
            {
               string friendBirthDayString = friend.Birthday;
               if (String.IsNullOrEmpty(friendBirthDayString))
               {
                  return int.MaxValue;
               }

               var birthDate = DateTime.Parse(friendBirthDayString);
               friend.Birthday = birthDate.ToString("MMMM d"); // normalize birthday formats
               return BirthdayCalculator.GetDaysBeforeBirthday(birthDate);
            }
            catch
            {
               return int.MaxValue;
            }
         }).Take(100);
         user.Friends.Data = friendsWithUpcomingBirthdays.ToList();
         return View(user);
      }

      return View("Error");
   }

   [FacebookAuthorize("friends_birthday")]
   public async Task<ActionResult> Search(string friendName, FacebookContext context)
   {
      var userFriends = await context.Client.GetCurrentUserFriendsAsync<MyAppUserFriend>();
      var friendsFound = String.IsNullOrEmpty(friendName) ?
          userFriends.ToList() :
          userFriends.Where(f => f.Name.ToLowerInvariant().Contains(friendName.ToLowerInvariant())).ToList();
      friendsFound.ForEach(f => f.Birthday = !String.IsNullOrEmpty(f.Birthday) ? DateTime.Parse(f.Birthday).ToString("MMMM d") : "");
      return View(friendsFound);
   }

   [FacebookAuthorize]
   public async Task<ActionResult> RecommendGifts(string friendId, FacebookContext context)
   {
      if (!String.IsNullOrEmpty(friendId))
      {
         var friend = await context.Client.GetFacebookObjectAsync<MyAppUserFriend>(friendId);
         if (friend != null)
         {
            var products = await RecommendationEngine.RecommendProductAsync(friend);
            ViewBag.FriendName = friend.Name;
            return View(products);
         }
      }

      return View("Error");
   }

   [FacebookAuthorize]
   public ActionResult About()
   {
      return View();
   }

   // This action will handle the redirects from FacebookAuthorizeFilter when
   // the app doesn't have all the required permissions specified in the FacebookAuthorizeAttribute.
   // The path to this action is defined under appSettings (in Web.config) with the key 'Facebook:AuthorizationRedirectPath'.
   public ActionResult Permissions(FacebookRedirectContext context)
   {
      if (ModelState.IsValid)
      {
         return View(context);
      }

      return View("Error");
   }
}
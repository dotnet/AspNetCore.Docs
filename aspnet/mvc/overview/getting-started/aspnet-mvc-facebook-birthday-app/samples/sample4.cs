public class FacebookRedirectContext
{
   public FacebookRedirectContext();

   public FacebookConfiguration Configuration { get; set; }
   public string OriginUrl { get; set; }
   public string RedirectUrl { get; set; }
   public string[] RequiredPermissions { get; set; }
}
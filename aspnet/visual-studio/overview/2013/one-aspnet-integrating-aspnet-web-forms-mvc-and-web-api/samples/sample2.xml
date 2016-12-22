public static void RegisterRoutes(RouteCollection routes)
{
    var settings = new FriendlyUrlSettings();
    settings.AutoRedirectMode = RedirectMode.Permanent;
    routes.EnableFriendlyUrls(settings);

    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { action = "Index", id = UrlParameter.Optional }
        );
}
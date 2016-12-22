public override void RegisterArea(AreaRegistrationContext context)
{
    // By default there is no "controller" parameter in the following line. 
    // Add one referencing "Home" as shown.
    context.MapRoute(
        "Mobile_default",
        "Mobile/{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
}
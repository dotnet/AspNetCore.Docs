protected void Application_Start()
{
    // (rest of method unchanged)

    // Using "order" value 1 means it will run after unordered filters
    // associated with specific controllers or actions, so the redirection 
    // location can be overridden for specific actions
    GlobalFilters.Filters.Add(new RedirectMobileDevicesToMobileAreaAttribute(), 1);
}
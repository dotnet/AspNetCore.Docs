protected override IReadOnlyList<IDirectRouteFactory> 
         GetActionRouteFactories(ActionDescriptor actionDescriptor)
{
    // Get all the route attributes decorated directly on the actions
    IReadOnlyList<IDirectRouteFactory> actionRouteFactories=base.GetActionRouteFactories(actionDescriptor);
    // Check if the route attribute on each action already has a route name and if no, 
    // generate a route name automatically
    // based on the convention: <ControllerName>_<ActionName> (ex: Customers_GetById)
    foreach (IDirectRouteFactory routeFactory in actionRouteFactories)
    {
        RouteAttribute routeAttr=routeFactory as RouteAttribute;
        if (string.IsNullOrEmpty(routeAttr.Name))
        {
            routeAttr.Name=actionDescriptor.ControllerDescriptor.ControllerName + "_" 
                  + actionDescriptor.ActionName;
        }
    }
    return actionRouteFactories;
}
protected override IReadOnlyList<IDirectRouteFactory> 
      GetControllerRouteFactories(ControllerDescriptor controllerDescriptor)
{
    // Get all the route attributes decorated directly on the controllers
    IReadOnlyList<IDirectRouteFactory> controllerRouteFactories=base.GetControllerRouteFactories(controllerDescriptor);
    // Check if the route attribute on each controller already has a route name and if no, 
    // generate a route name automatically
    // based on the convention: <ControllerName>Route (ex: CustomersRoute)
    foreach (IDirectRouteFactory routeFactory in controllerRouteFactories)
    {
        RouteAttribute routeAttr=routeFactory as RouteAttribute;
        if (string.IsNullOrEmpty(routeAttr.Name))
        {
            routeAttr.Name=controllerDescriptor.ControllerName + "Route";
        }
    }
    return controllerRouteFactories;
}
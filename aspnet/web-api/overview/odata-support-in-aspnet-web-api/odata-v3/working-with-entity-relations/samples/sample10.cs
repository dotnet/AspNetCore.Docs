// Helper method to extract the key from an OData link URI.
private TKey GetKeyFromLinkUri<TKey>(Uri link)
{
    TKey key = default(TKey);

    // Get the route that was used for this request.
    IHttpRoute route = Request.GetRouteData().Route;

    // Create an equivalent self-hosted route. 
    IHttpRoute newRoute = new HttpRoute(route.RouteTemplate, 
        new HttpRouteValueDictionary(route.Defaults), 
        new HttpRouteValueDictionary(route.Constraints),
        new HttpRouteValueDictionary(route.DataTokens), route.Handler);

    // Create a fake GET request for the link URI.
    var tmpRequest = new HttpRequestMessage(HttpMethod.Get, link);

    // Send this request through the routing process.
    var routeData = newRoute.GetRouteData(
        Request.GetConfiguration().VirtualPathRoot, tmpRequest);

    // If the GET request matches the route, use the path segments to find the key.
    if (routeData != null)
    {
        ODataPath path = tmpRequest.GetODataPath();
        var segment = path.Segments.OfType<KeyValuePathSegment>().FirstOrDefault();
        if (segment != null)
        {
            // Convert the segment into the key type.
            key = (TKey)ODataUriUtils.ConvertFromUriLiteral(
                segment.Value, ODataVersion.V3);
        }
    }
    return key;
}
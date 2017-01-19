public HttpResponseMessage Get(
    [ValueProvider(typeof(CookieValueProviderFactory))] GeoPoint location)
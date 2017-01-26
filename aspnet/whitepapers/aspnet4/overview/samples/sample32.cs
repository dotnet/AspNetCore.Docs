public class CustomProvider : HttpCapabilitiesProvider 
{ 
	public override HttpBrowserCapabilities 
	GetBrowserCapabilities(HttpRequest request) 
	{ 
		string cacheKey = BuildCacheKey(); 
		int cacheTime = GetCacheTime(); 
		HttpBrowserCapabilities browserCaps = 
		HttpContext.Current.Cache[cacheKey] as 
		HttpBrowserCapabilities; 
		if (browserCaps == null) 
		{ 
			HttpBrowserCapabilities browserCaps = new 
			HttpBrowserCapabilities(); 
			Hashtable values = new Hashtable(180, 
			StringComparer.OrdinalIgnoreCase); 
			values[String.Empty] = request.UserAgent; 
			values["browser"] = "MyCustomBrowser"; 
			browserCaps.Capabilities = values; 
			HttpContext.Current.Cache.Insert(cacheKey, 
			browserCaps, null, DateTime.MaxValue, 
			TimeSpan.FromSeconds(cacheTime));
		} 
		return browserCaps; 
	} 
}
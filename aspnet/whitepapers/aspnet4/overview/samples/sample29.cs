public class CustomProvider : HttpCapabilitiesProvider 
{ 
	public override HttpBrowserCapabilities 
	GetBrowserCapabilities(HttpRequest request) 
	{ 
		HttpBrowserCapabilities browserCaps = new HttpBrowserCapabilities(); 
		Hashtable values = new Hashtable(180, StringComparer.OrdinalIgnoreCase); 
		values[String.Empty] = request.UserAgent; 
		values["browser"] = "MyCustomBrowser"; 
		browserCaps.Capabilities = values; 
		return browserCaps;
	} 
}
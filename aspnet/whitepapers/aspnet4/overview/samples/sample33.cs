public class CustomProvider : HttpCapabilitiesEvaluator 
{ 
	public override HttpBrowserCapabilities 
	GetBrowserCapabilities(HttpRequest request) 
	{ 
		HttpBrowserCapabilities browserCaps = 
		base.GetHttpBrowserCapabilities(request);
		if (browserCaps.Browser == "Unknown") 
		{ 
			browserCaps = MyBrowserCapabilitiesEvaulator(request); 
		} 
		return browserCaps; 
	} 
}
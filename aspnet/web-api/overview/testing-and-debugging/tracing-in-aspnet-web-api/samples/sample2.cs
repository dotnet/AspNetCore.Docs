public static class WebApiConfig
{
	public static void Register(HttpConfiguration config)
	{
		// New code
		config.EnableSystemDiagnosticsTracing();

		// Other configuration code not shown.
	}
}
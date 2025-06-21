SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
    .AddJsonSessionSerializer(options =>
    {
        // Serialization/deserialization requires each session key to be registered to a type
        options.RegisterKey<int>("test-value");
        options.RegisterKey<SessionDemoModel>("SampleSessionItem");
    })
    // Provide a strong API key that will be used to authenticate the request on the remote app for querying the session
    // ApiKey is a string representing a GUID
    .AddRemoteAppServer(options => options.ApiKey = ConfigurationManager.AppSettings["RemoteAppApiKey"])
    .AddSessionServer();
public override bool OnStart()
{
    ServicePointManager.DefaultConnectionLimit = 12;

    // New code:
    var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Endpoint1"];
    string baseUri = String.Format("{0}://{1}", 
        endpoint.Protocol, endpoint.IPEndpoint);

    Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseUri), 
        "Information");

    _app = WebApp.Start<Startup>(new StartOptions(url: baseUri));
    return base.OnStart();
}
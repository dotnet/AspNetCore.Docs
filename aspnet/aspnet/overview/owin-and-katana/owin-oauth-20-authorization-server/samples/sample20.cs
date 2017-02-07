class Program
{
    private static WebServerClient _webServerClient;
    private static string _accessToken;

    static void Main(string[] args)
    {
        InitializeWebServerClient();

        Console.WriteLine("Requesting Token...");
        RequestToken();

        Console.WriteLine("Access Token: {0}", _accessToken);

        Console.WriteLine("Access Protected Resource");
        AccessProtectedResource();            
    }

    private static void InitializeWebServerClient()
    {
        var authorizationServerUri = new Uri(Paths.AuthorizationServerBaseAddress);
        var authorizationServer = new AuthorizationServerDescription
        {
            AuthorizationEndpoint = new Uri(authorizationServerUri, Paths.AuthorizePath),
            TokenEndpoint = new Uri(authorizationServerUri, Paths.TokenPath)
        };
        _webServerClient = new WebServerClient(authorizationServer, Clients.Client1.Id, Clients.Client1.Secret);
    }

    private static void RequestToken()
    {
        var state = _webServerClient.GetClientAccessToken(new[] { "bio", "notes" });
        _accessToken = state.AccessToken;
    }

    private static void AccessProtectedResource()
    {
        var resourceServerUri = new Uri(Paths.ResourceServerBaseAddress);
        var client = new HttpClient(_webServerClient.CreateAuthorizingHandler(_accessToken));
        var body = client.GetStringAsync(new Uri(resourceServerUri, Paths.MePath)).Result;
        Console.WriteLine(body);
    }
}
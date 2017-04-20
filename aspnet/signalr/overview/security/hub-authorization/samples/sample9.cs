class Program
{
    static void Main(string[] args)
    {
        var connection = new HubConnection("http://www.contoso.com/");
        connection.Credentials = CredentialCache.DefaultCredentials;
        connection.Start().Wait();
    }
}
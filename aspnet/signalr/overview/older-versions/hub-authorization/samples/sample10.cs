class Program
{
    static void Main(string[] args)
    {
        var connection = new HubConnection("http://www.contoso.com/");
        connection.Headers.Add("myauthtoken", /* token data */);
        connection.Start().Wait();
    }
}
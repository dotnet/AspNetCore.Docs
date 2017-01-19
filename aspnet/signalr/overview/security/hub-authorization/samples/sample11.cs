class Program
{
    static void Main(string[] args)
    {
        var connection = new HubConnection("http://www.contoso.com/");
        connection.AddClientCertificate(X509Certificate.CreateFromCertFile("MyCert.cer"));
        connection.Start().Wait();
    }
}
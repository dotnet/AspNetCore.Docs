static void Main()
{
    var baseAddress = new Uri("http://localhost:5000");

    var config = new HttpSelfHostConfiguration(baseAddress);
    config.Routes.MapHttpRoute("default", "{controller}");
       
    using (var svr = new HttpSelfHostServer(config))
    {
        svr.OpenAsync().Wait();
        Console.WriteLine("Press Enter to quit.");
        Console.ReadLine();
    }
}
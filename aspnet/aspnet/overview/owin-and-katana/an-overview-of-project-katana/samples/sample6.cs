static void Main(string[] args)
{
    const string baseUrl = "http://localhost:5000/";

    using (WebApplication.Start<Startup>(new StartOptions { Url = baseUrl })) 
    {
        Console.WriteLine("Press Enter to quit.");
        Console.ReadKey();
    }
}
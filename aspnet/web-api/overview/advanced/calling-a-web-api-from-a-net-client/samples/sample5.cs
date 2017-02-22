static async Task RunAsync()
{
    // New code:
    client.BaseAddress = new Uri("http://localhost:55268/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    Console.ReadLine();
}
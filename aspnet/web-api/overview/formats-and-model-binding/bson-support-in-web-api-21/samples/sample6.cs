static async Task RunAsync()
{
    using (HttpClient client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost");

        // Set the Accept header for BSON.
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

        // Send GET request.
        result = await client.GetAsync("api/books/1");
        result.EnsureSuccessStatusCode();

        // Use BSON formatter to deserialize the result.
        MediaTypeFormatter[] formatters = new MediaTypeFormatter[] {
            new BsonMediaTypeFormatter()
        };

        var book = await result.Content.ReadAsAsync<Book>(formatters);
    }
}
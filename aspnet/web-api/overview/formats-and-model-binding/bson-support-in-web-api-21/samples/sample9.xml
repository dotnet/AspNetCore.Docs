static async Task RunAsync()
{
    using (HttpClient client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:15192");

        // Set the Accept header for BSON.
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

        var book = new Book()
        {
            Author = "Jane Austen",
            Title = "Emma",
            Price = 9.95M,
            PublicationDate = new DateTime(1815, 1, 1)
        };

        // POST using the BSON formatter.
        MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
        var result = await client.PostAsync("api/books", book, bsonFormatter);
        result.EnsureSuccessStatusCode();
    }
}
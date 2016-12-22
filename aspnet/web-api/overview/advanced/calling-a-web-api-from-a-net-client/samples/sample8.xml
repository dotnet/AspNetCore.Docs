static async Task<Uri> CreateProductAsync(Product product)
{
    HttpResponseMessage response = await client.PostAsJsonAsync("api/products", product);
    response.EnsureSuccessStatusCode();

    // Return the URI of the created resource.
    return response.Headers.Location;
}
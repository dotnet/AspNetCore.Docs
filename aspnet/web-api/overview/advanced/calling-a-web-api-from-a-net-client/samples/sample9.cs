static async Task<Product> UpdateProductAsync(Product product)
{
    HttpResponseMessage response = await client.PutAsJsonAsync($"api/products/{product.Id}", product);
    response.EnsureSuccessStatusCode();

    // Deserialize the updated product from the response body.
    product = await response.Content.ReadAsAsync<Product>();
    return product;
}

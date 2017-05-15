static async Task<HttpStatusCode> DeleteProductAsync(string id)
{
    HttpResponseMessage response = await client.DeleteAsync($"api/products/{id}");
    return response.StatusCode;
}

public async Task<List<Gizmo>> GetGizmosAsync()
{
    var uri = Util.getServiceUri("Gizmos");
    using (HttpClient httpClient = new HttpClient())
    {
        var response = await httpClient.GetAsync(uri);
        return (await response.Content.ReadAsAsync<List<Gizmo>>());
    }
}
public async Task<List<Gizmo>> GetGizmosAsync(string uri,
	CancellationToken cancelToken = default(CancellationToken))
{
	using (HttpClient httpClient = new HttpClient())
	{
		var response = await httpClient.GetAsync(uri, cancelToken);
		return (await response.Content.ReadAsAsync<List<Gizmo>>());
	}
}
public async Task<List<Gizmo>> GetGizmosAsync()
{
    var uri = Util.getServiceUri("Gizmos");
    using (WebClient webClient = new WebClient())
    {
        return JsonConvert.DeserializeObject<List<Gizmo>>(
            await webClient.DownloadStringTaskAsync(uri)
        );
    }
}

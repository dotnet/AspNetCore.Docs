public class GizmoService
{
    public async Task<List<Gizmo>> GetGizmosAsync(
        // Implementation removed.
       
    public List<Gizmo> GetGizmos()
    {
        var uri = Util.getServiceUri("Gizmos");
        using (WebClient webClient = new WebClient())
        {
            return JsonConvert.DeserializeObject<List<Gizmo>>(
                webClient.DownloadString(uri)
            );
        }
    }
}
public async Task NotifyUpdates()
{
    var hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();
    if (hubContext != null)
    {
         var stats = await this.GenerateStatistics();
         hubContext.Clients.All.updateStatistics(stats);
    }
}
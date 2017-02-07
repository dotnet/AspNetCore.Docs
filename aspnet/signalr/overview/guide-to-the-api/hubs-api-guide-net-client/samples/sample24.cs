public class StockTickerHub : Hub
{
    public void JoinGroup(string groupName)
    {
        Groups.Add(Context.ConnectionId, groupName); 
    }
}
// For the complete example, see
// http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-server-broadcast-with-signalr-20
// This sample only shows code that passes connection ID to the non-Hub class,
// in order to simulate Clients.Others.
public class MoveShapeHub : Hub
{
    // Code not shown puts a singleton instance of Broadcaster in this variable.
    private Broadcaster _broadcaster;

    public void UpdateModel(ShapeModel clientModel)
    {
        clientModel.LastUpdatedBy = Context.ConnectionId;
        // Update the shape model within our broadcaster
        _broadcaster.UpdateShape(clientModel);
    }
}

public class Broadcaster
{
    public Broadcaster()
    {
        _hubContext = GlobalHost.ConnectionManager.GetHubContext<MoveShapeHub>();
    }

    public void UpdateShape(ShapeModel clientModel)
    {
        _model = clientModel;
        _modelUpdated = true;
    }

    // Called by a Timer object.
    public void BroadcastShape(object state)
    {
        if (_modelUpdated)
        {
            _hubContext.Clients.AllExcept(_model.LastUpdatedBy).updateShape(_model);
            _modelUpdated = false;
        }
    }
}
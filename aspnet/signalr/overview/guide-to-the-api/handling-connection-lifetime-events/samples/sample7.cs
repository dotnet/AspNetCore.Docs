public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
{
    if (stopCalled)
    {
        Console.WriteLine(String.Format("Client {0} explicitly closed the connection.", Context.ConnectionId));
    }
    else
    {
        Console.WriteLine(String.Format("Client {0} timed out .", Context.ConnectionId));
    }
            
    return base.OnDisconnected(stopCalled);
}

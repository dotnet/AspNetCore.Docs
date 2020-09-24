private AsyncServerStreamingCall<HelloReply> _call;

public void StartStream()
{
    _call = client.SayHellos(new HelloRequest { Name = "World" });

    // Read response in background task.
    _ = Task.Run(async () =>
    {
        await foreach (var response in _call.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine("Greeting: " + response.Message);
        }
    });
}

public void StopStream()
{
    _call.Dispose();
}
#region snippet_1
var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
    {
        HttpClient = new HttpClient(handler)
    });

var client = new Greeter.GreeterClient(channel);
var response = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
#endregion

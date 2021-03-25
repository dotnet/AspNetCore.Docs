using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = channel.CreateGrpcService<IGreeterService>();

var reply = await client.SayHelloAsync(
    new HelloRequest { Name = "GreeterClient" });

Console.WriteLine($"Greeting: {reply.Message}");

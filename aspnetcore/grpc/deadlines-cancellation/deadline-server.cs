public override async Task<HelloReply> SayHello(HelloRequest request,
    ServerCallContext context)
{
    var user = await _databaseContext.GetUserAsync(request.Name,
        context.CancellationToken);

    return new HelloReply { Message = "Hello " + user.DisplayName };
}
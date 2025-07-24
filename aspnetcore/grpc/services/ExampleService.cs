using Grpc.Core;

namespace GrcpServices;

public class ExamplesService : ExampleService.ExampleServiceBase
{
    // <snippet_UnaryCall>
    public override Task<ExampleResponse> UnaryCall(ExampleRequest request,
        ServerCallContext context)
    {
        var response = new ExampleResponse();
        return Task.FromResult(response);
    }
    // </snippet_UnaryCall>


    // <snippet_UnaryCallRequestHeaders>
    public override Task<ExampleResponse> UnaryCall(ExampleRequest request,
        ServerCallContext context)
    {
        var userAgent = context.RequestHeaders.GetValue("user-agent");
        // ...

        return Task.FromResult(new ExampleResponse());
    }
    // </snippet_UnaryCallRequestHeaders>


    // <snippet_StreamingFromServer>
    public override async Task StreamingFromServer(ExampleRequest request,
        IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
    {
        for (var i = 0; i < 5; i++)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
    // </snippet_StreamingFromServer>

    // <snippet_StreamingFromServerUsingCancellationToken>
    public override async Task StreamingFromServer(ExampleRequest request,
        IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
        }
    }
    // </snippet_StreamingFromServerUsingCancellationToken>


    // <snippet_StreamingFromClient>
    public override async Task<ExampleResponse> StreamingFromClient(
        IAsyncStreamReader<ExampleRequest> requestStream, ServerCallContext context)
    {
        await foreach (var message in requestStream.ReadAllAsync())
        {
            // ...
        }
        return new ExampleResponse();
    }
    // </snippet_StreamingFromClient>

    // <snippet_StreamingBothWays>
    public override async Task StreamingBothWays(IAsyncStreamReader<ExampleRequest> requestStream,
        IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
    {
        await foreach (var message in requestStream.ReadAllAsync())
        {
            await responseStream.WriteAsync(new ExampleResponse());
        }
    }
    // </snippet_StreamingBothWays>

    // <snippet_StreamingBothWaysComplex>
    public override async Task StreamingBothWays(IAsyncStreamReader<ExampleRequest> requestStream,
        IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
    {
        // Read requests in a background task.
        var readTask = Task.Run(async () =>
        {
            await foreach (var message in requestStream.ReadAllAsync())
            {
                // Process request.
            }
        });

        // Send responses until the client signals that it is complete.
        while (!readTask.IsCompleted)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
        }
    }
    // </snippet_StreamingBothWaysComplex>
}
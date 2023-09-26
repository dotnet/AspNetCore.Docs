// <snippet_StreamingFromServer>
public override async Task StreamingFromServer(ExampleRequest request,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    _ = Task.Run(async () =>
    {
        for (var i = 0; i < 5; i++)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    });

    await PerformLongRunningWorkAsync();
}
// </snippet_StreamingFromServer>


// <snippet_StreamingFromServerWriteTask>
public override async Task StreamingFromServer(ExampleRequest request,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    var writeTask = Task.Run(async () =>
    {
        for (var i = 0; i < 5; i++)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    });

    await PerformLongRunningWorkAsync();

    await writeTask;
}
// </snippet_StreamingFromServerWriteTask>

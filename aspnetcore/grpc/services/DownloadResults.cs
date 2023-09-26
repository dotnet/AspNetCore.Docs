public override async Task DownloadResults(DataRequest request,
        IServerStreamWriter<DataResult> responseStream, ServerCallContext context)
{
    var channel = Channel.CreateBounded<DataResult>(new BoundedChannelOptions(capacity: 5));

    var consumerTask = Task.Run(async () =>
    {
        // Consume messages from channel and write to response stream.
        await foreach (var message in channel.Reader.ReadAllAsync())
        {
            await responseStream.WriteAsync(message);
        }
    });

    var dataChunks = request.Value.Chunk(size: 10);

    // Write messages to channel from multiple threads.
    await Task.WhenAll(dataChunks.Select(
        async c =>
        {
            var message = new DataResult { BytesProcessed = c.Length };
            await channel.Writer.WriteAsync(message);
        }));

    // Complete writing and wait for consumer to complete.
    channel.Writer.Complete();
    await consumerTask;
}
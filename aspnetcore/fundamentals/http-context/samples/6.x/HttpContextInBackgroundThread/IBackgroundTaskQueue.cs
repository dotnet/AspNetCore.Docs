namespace HttpContextInBackgroundThread;

public interface IBackgroundTaskQueue
{
    ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask<string>> workItem);

    ValueTask<Func<CancellationToken, ValueTask<string>>> DequeueAsync(
        CancellationToken cancellationToken);
}

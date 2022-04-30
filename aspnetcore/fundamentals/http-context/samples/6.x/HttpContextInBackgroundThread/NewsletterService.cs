using System.Collections.Concurrent;

namespace HttpContextInBackgroundThread;

public class NewsletterService : BackgroundService
{
    private readonly IAsyncConcurrentQueue<EmailMessage> _queue;

    public NewsletterService(IAsyncConcurrentQueue<EmailMessage> queue)
    {
        _queue = queue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var pendingTasks = new ConcurrentDictionary<Task, byte>();
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = await _queue.DequeueAsync(stoppingToken);
            Task task = SendEmailAsync();
            pendingTasks.TryAdd(task, 0);

            // Run and forget rather than await so that we can process the subsequent messages.
            _ = task.ContinueWith(
                (innerTask, innerPendingTasks) => ((ConcurrentDictionary<Task, byte>)innerPendingTasks!).TryRemove(innerTask, out _),
                pendingTasks,
                TaskScheduler.Default);
        }

        await Task.WhenAll(pendingTasks.Keys);
    }

    private async Task SendEmailAsync()
    {
        await Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await base.StopAsync(stoppingToken);
    }
}

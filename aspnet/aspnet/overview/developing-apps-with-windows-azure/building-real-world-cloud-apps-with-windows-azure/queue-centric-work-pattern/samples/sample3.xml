public class WorkerRole : RoleEntryPoint
{
    public override void Run()
    {
        Task task = RunAsync(tokenSource.Token);
        try
        {
            task.Wait();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Unhandled exception in FixIt worker role.");
        }
    }

    private async Task RunAsync(CancellationToken token)
    {
        using (var scope = container.BeginLifetimeScope())
        {
            IFixItQueueManager queueManager = scope.Resolve<IFixItQueueManager>();
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await queueManager.ProcessMessagesAsync();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception in worker role Run loop.");
                }
                await Task.Delay(1000);
            }
        }
    }
    // Other code not shown.
}
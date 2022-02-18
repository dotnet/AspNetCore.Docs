public class TimerService : IDisposable
{
    private int elapsedCount;
    private readonly static TimeSpan heartbeatTickRate = TimeSpan.FromSeconds(5);
    private readonly ILogger<TimerService> logger;
    private readonly NotifierService notifier;
    private PeriodicTimer? timer;

    public TimerService(NotifierService notifier,
        ILogger<TimerService> logger)
    {
        this.notifier = notifier;
        this.logger = logger;
    }

    public async Task Start()
    {
        if (timer is null)
        {
            timer = new(heartbeatTickRate);
            logger.LogInformation("Started");

            using (timer)
            {
                while (await timer.WaitForNextTickAsync())
                {
                    elapsedCount += 1;
                    await notifier.Update("elapsedCount", elapsedCount);
                    logger.LogInformation($"elapsedCount: {elapsedCount}");
                }
            }
        }
    }

    public void Dispose()
    {
        timer?.Dispose();
    }
}

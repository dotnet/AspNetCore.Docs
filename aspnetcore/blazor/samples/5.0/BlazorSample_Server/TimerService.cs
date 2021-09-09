using System;
using System.Timers;
using Microsoft.Extensions.Logging;

public class TimerService : IDisposable
{
    private int elapsedCount;
    private readonly ILogger<TimerService> logger;
    private readonly NotifierService notifier;
    private Timer timer;

    public TimerService(NotifierService notifier, ILogger<TimerService> logger)
    {
        this.notifier = notifier;
        this.logger = logger;
    }

    public void Start()
    {
        if (timer is null)
        {
            timer = new();
            timer.AutoReset = true;
            timer.Interval = 10000;
            timer.Elapsed += HandleTimer;
            timer.Enabled = true;
            logger.LogInformation("Started");
        }
    }

    private async void HandleTimer(object source, ElapsedEventArgs e)
    {
        elapsedCount += 1;
        await notifier.Update("elapsedCount", elapsedCount);
        logger.LogInformation($"elapsedCount: {elapsedCount}");
    }

    public void Dispose()
    {
        timer?.Dispose();
    }
}

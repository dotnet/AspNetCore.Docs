namespace HttpContextInBackgroundThread;

public class NewsletterService : BackgroundService
{
    private readonly IEmailService _emailService;
    private Timer _timer = null!;

    public NewsletterService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        void StartMailing(object? state)
        {
            _emailService.SendEmail("microsoft@aka.ms");
        }

        _timer = new Timer(StartMailing,
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(30));

        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _timer.Change(Timeout.Infinite, 0);

        await base.StopAsync(stoppingToken);
    }
}


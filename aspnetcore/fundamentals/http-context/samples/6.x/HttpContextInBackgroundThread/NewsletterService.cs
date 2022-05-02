namespace HttpContextInBackgroundThread
{
    public class NewsletterService : BackgroundService
    {
        private readonly ILogger<NewsletterService> _logger;
        private readonly IEmailService _emailService;
        private Timer _timer = null!;

        public NewsletterService(ILogger<NewsletterService> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Newsletter Hosted Service is running.");

            await BackgroundProcessing(stoppingToken);
        }

        private Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            _timer = new Timer(StartMailing,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            async void StartMailing(object? state)
            {
                await _emailService.SendEmail(stoppingToken);
            }

            return Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Newsletter Hosted Service is stopping.");
            await _timer.DisposeAsync();
            await base.StopAsync(stoppingToken);
        }
    }
}

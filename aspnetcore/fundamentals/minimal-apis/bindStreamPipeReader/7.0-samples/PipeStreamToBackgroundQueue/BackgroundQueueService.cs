using System.Text.Json;
using System.Threading.Channels;

namespace BackgroundQueueService;

class BackgroundQueue : BackgroundService
{
    private readonly Channel<Stream> _queue;
    private readonly ILogger<BackgroundQueue> _logger;

    public BackgroundQueue(Channel<Stream> queue, ILogger<BackgroundQueue> logger)
    {
        _queue = queue;
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var dataStream in _queue.Reader.ReadAllAsync(stoppingToken))
        {
            // reset the stream to the beginning
            dataStream.Position = 0;

            try
            {   
                var person = JsonSerializer.Deserialize<Person>(dataStream)!;
                 _logger.LogInformation($"{person.Name} is {person.Age} years and from {person.Country}");
                // you could do something else with the data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

class Person
{
    public string Name { get; set; } = String.Empty;
    public int Age { get; set; }
    public string Country { get; set; } = String.Empty;
}

using System.Text.Json;
using System.Threading.Channels;

namespace BackGroundQueueService;

class BackGroundQueue : BackgroundService
{
    private readonly ILogger<BackGroundQueue> _logger;

    public BackGroundQueue(Channel<Stream> queue, ILogger<BackGroundQueue> logger)
    {
        _queue = queue;
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        await foreach (var dataStream in _queue.Reader.ReadAllAsync())
        {
            // reset the stream to the beginning
            dataStream.Position = 0;

            var reader = new StreamReader(dataStream);
            try
            {   
                var Person = JsonSerializer.Deserialize<Person>(await reader.ReadToEndAsync())!;
                 _logger.LogInformation($"{Person.Name} is {Person.Age} years and from {Person.Country}");
                // you could do something else with the data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }


        return;

    }
}

class Person
{
    public string Name { get; set; } = String.Empty;
    public int Age { get; set; }
    public string Country { get; set; } = String.Empty;
}

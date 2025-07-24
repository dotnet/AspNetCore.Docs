using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// <snippet_string>
app.MapGet("/string-item", (CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<string> GetHeartRate(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var heartRate = Random.Shared.Next(60, 100);
            yield return $"Heart Rate: {heartRate} bpm";
            await Task.Delay(2000, cancellationToken);
        }
    }

    return TypedResults.ServerSentEvents(GetHeartRate(cancellationToken),
                                                  eventType: "heartRate");
});
// </snippet_string>

// <snippet_json>
app.MapGet("/json-item", (CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<HeartRateRecord> GetHeartRate(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var heartRate = Random.Shared.Next(60, 100);
            yield return HeartRateRecord.Create(heartRate);
            await Task.Delay(2000, cancellationToken);
        }
    }

    return TypedResults.ServerSentEvents(GetHeartRate(cancellationToken),
                                                  eventType: "heartRate");
});
// </snippet_json>

// <snippet_item>
app.MapGet("sse-item", (CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<SseItem<int>> GetHeartRate(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var heartRate = Random.Shared.Next(60, 100);
            yield return new SseItem<int>(heartRate, eventType: "heartRate")
            {
                ReconnectionInterval = TimeSpan.FromMinutes(1)
            };
            await Task.Delay(2000, cancellationToken);
        }
    }

    return TypedResults.ServerSentEvents(GetHeartRate(cancellationToken));
});
// </snippet_item>


app.Run();


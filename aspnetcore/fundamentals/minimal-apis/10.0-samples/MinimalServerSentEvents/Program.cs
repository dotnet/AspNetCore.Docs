using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/json-item"));


app.MapGet("/string-item", (CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<string> GetHeartRate(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var heartRate = Random.Shared.Next(60, 100);
            yield return $"Hear Rate: {heartRate} bpm";
            await Task.Delay(2000, cancellationToken);
        }
    }

    return TypedResults.ServerSentEvents(GetHeartRate(cancellationToken), eventType: "heartRate");
});

app.MapGet("/json-item", (CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<HearRate> GetHeartRate(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var heartRate = Random.Shared.Next(60, 100);
            yield return HearRate.Create(heartRate);
            await Task.Delay(2000, cancellationToken);
        }
    }

    return TypedResults.ServerSentEvents(GetHeartRate(cancellationToken), eventType: "heartRate");
});

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

app.Run();

public record HearRate(DateTime Timestamp, int HeartRate)
{
    public static HearRate Create(int heartRate) => new(DateTime.UtcNow, heartRate);
}
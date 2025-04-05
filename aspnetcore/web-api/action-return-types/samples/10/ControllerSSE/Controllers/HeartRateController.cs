using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Net.ServerSentEvents;

[ApiController]
[Route("[controller]")]

public class HeartRateController : ControllerBase
{
    // /HeartRate/json-item
    [HttpGet("json-item")]
    public IResult GetHeartRateJson(CancellationToken cancellationToken)
    {
        async IAsyncEnumerable<HearRate> StreamHeartRates(
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var heartRate = Random.Shared.Next(60, 100);
                yield return HearRate.Create(heartRate);
                await Task.Delay(2000, cancellationToken);
            }
        }

        return TypedResults.ServerSentEvents(StreamHeartRates(cancellationToken), eventType: "heartRate");
    }

    // /HeartRate/string-item
    [HttpGet("string-item")]

    public IResult GetHeartRateString(CancellationToken cancellationToken)
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
    }

    // /HeartRate/sse-item
    [HttpGet("sse-item")]

    public IResult GetHeartRateSSE(CancellationToken cancellationToken)
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
    }
}

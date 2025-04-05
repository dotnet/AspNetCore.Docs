public record HearRate(DateTime Timestamp, int HeartRate)
{
    public static HearRate Create(int heartRate) => new(DateTime.UtcNow, heartRate);
}

public record HeartRate(DateTime Timestamp, int HeartRate)
{
    public static HeartRate Create(int heartRate) => new(DateTime.UtcNow, heartRate);
}

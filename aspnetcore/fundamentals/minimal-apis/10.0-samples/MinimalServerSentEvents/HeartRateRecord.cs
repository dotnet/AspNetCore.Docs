public record HeartRateRecord(DateTime Timestamp, int HeartRate)
{
    public static HeartRateRecord Create(int heartRate) => new(DateTime.UtcNow, heartRate);
}

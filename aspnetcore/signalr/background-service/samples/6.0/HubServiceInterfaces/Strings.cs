namespace HubServiceInterfaces;

public static class Strings
{
    public static string HubUrl => "https://localhost:5001/hubs/clock";

    public static class Events
    {
        public static string TimeSent => nameof(IClock.ShowTime);
    }
}

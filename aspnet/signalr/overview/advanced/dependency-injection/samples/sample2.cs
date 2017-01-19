// Without dependency injection.
class SomeComponent
{
    ILogger _logger = new FileLogger(@"C:\logs\log.txt");

    public void DoSomething()
    {
        _logger.LogMessage("DoSomething");
    }
}
// With dependency injection.
class SomeComponent
{
    ILogger _logger;

    // Inject ILogger into the object.
    public SomeComponent(ILogger logger)
    {
        if (logger == null)
        {
            throw new NullReferenceException("logger");
        }
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.LogMessage("DoSomething");
    }
}
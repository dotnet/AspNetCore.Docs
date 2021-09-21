public class InjectableClass
{
  // This can be used to access the IConfiguration service for your application
  private readonly IConfiguration configurationRef;

  public InjectableClass(IConfiguration configuration)
  {
    configurationRef = configuration;
  }

  public void printConfigurationValueToConsole()
  {
    var configurationValue = configurationRef["configurationKey"];
    System.Console.WriteLine(configurationValue);
  }
}

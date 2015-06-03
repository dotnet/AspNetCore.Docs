using Microsoft.Framework.ConfigurationModel;

namespace ConfigDemo
{
    public class ConfigSetup
    {
        public ConfigSetup()
        {
            // Make individual calls to AddXXX extension methods
            var config = new Configuration();
            config.AddJsonFile("config.json");
            config.AddEnvironmentVariables();

            // Fluent configuration
            var configFluent = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }
    }
}

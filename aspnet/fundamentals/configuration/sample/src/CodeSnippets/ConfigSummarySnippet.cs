using Microsoft.Extensions.Configuration;

namespace CodeSnippets
{
    public class ConfigSummarySnippet
    {
        public ConfigSummarySnippet()
        {
            // Everything between SNIPPET-START and SNIPPET-END will be inlined in the doc!
            // SNIPPET-START
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection();
            var config = builder.Build();
            config["somekey"] = "somevalue";

            // do some other work

            var setting = config["somekey"]; // also returns "somevalue"
            // SNIPPET-END
        }
    }
}

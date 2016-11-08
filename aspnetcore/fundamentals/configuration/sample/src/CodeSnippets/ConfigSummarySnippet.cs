using Microsoft.Extensions.Configuration;

namespace CodeSnippets
{
    public class ConfigSummarySnippet
    {
        public ConfigSummarySnippet()
        {
            #region snippet_1
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection();
            var config = builder.Build();
            config["somekey"] = "somevalue";

            // do some other work

            var setting = config["somekey"]; // also returns "somevalue"
            #endregion
        }
    }
}

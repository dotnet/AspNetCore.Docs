using Microsoft.Extensions.Configuration;

namespace ConfigSample
{
// <snippet_Class>
    public class Service
    {
        private readonly IConfiguration _config;

        public Service(IConfiguration config) =>
            _config = config;

        public void DoSomething()
        {
            var configSettingValue = _config["ConfigSetting"];

            // ...
        }
    }
// </snippet_Class>
}

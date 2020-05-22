
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace OptionsValidationSample.Configuration
{
    #region snippet
    public class MyConfigValidation : IValidateOptions<MyConfig>
    {
        public MyConfig _config { get; private set; }

        public  MyConfigValidation(IConfiguration config)
        {
            _config = config.GetSection(MyConfig.MyConfigName)
                .Get<MyConfig>();
        }

        public ValidateOptionsResult Validate(string name, MyConfig options)
        {
            string vor=null;
            var rx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
            var match = rx.Match(options.Key1);

            if (string.IsNullOrEmpty(match.Value))
            {
                vor = $"{options.Key1} doesn't match RegEx \n";
            }

            if (_config.Key2 != default)
            {
                if(_config.Key3 <= _config.Key2)
                {
                    vor +=  "Key3 mst be > than Key2.";
                }
            }

            if (vor != null)
            {
                return ValidateOptionsResult.Fail(vor);
            }

            return ValidateOptionsResult.Success;
        }
    }
    #endregion
}

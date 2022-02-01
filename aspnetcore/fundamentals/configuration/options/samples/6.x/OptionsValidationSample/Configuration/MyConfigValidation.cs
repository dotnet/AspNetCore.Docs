
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace OptionsValidationSample.Configuration
{
    // <snippet>
    public class MyConfigValidation : IValidateOptions<MyConfigOptions>
    {
        public MyConfigOptions _config { get; private set; }

        public  MyConfigValidation(IConfiguration config)
        {
            _config = config.GetSection(MyConfigOptions.MyConfig)
                .Get<MyConfigOptions>();
        }

        public ValidateOptionsResult Validate(string name, MyConfigOptions options)
        {
            string? vor = null;
            var rx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
            var match = rx.Match(options.Key1!);

            if (string.IsNullOrEmpty(match.Value))
            {
                vor = $"{options.Key1} doesn't match RegEx \n";
            }

            if ( options.Key2 < 0 || options.Key2 > 1000)
            {
                vor = $"{options.Key2} doesn't match Range 0 - 1000 \n";
            }

            if (_config.Key2 != default)
            {
                if(_config.Key3 <= _config.Key2)
                {
                    vor +=  "Key3 must be > than Key2.";
                }
            }

            if (vor != null)
            {
                return ValidateOptionsResult.Fail(vor);
            }

            return ValidateOptionsResult.Success;
        }
    }
    // </snippet>
}

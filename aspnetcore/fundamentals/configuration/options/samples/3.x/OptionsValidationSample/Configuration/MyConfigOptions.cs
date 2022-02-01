
using System.ComponentModel.DataAnnotations;

namespace OptionsValidationSample.Configuration
{
    // <snippet>
    public class MyConfigOptions
    {
        public const string MyConfig = "MyConfig";

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Key1 { get; set; }
        [Range(0, 1000,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Key2 { get; set; }
        public int Key3 { get; set; }
    }
    // </snippet>
}

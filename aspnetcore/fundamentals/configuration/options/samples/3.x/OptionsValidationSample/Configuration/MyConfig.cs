
using System.ComponentModel.DataAnnotations;

namespace OptionsValidationSample.Configuration
{
    public class MyConfig
    {
        [Required]
        public string Key1 { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{4,40}$")]
        public string Key2 { get; set; }
        public string Key3 { get; set; }
    }
}

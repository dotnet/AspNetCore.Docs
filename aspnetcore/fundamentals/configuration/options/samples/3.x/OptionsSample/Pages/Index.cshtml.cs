using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

namespace SampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyOptions _options;
        private readonly MyOptionsWithDelegateConfig _optionsWithDelegateConfig;
        private readonly MySubOptions _subOptions;
        private readonly MyOptions _snapshotOptions;
        private readonly MyOptions _named_options_1;
        private readonly MyOptions _named_options_2;

        // <snippet2>
        public IndexModel(
            IOptionsMonitor<MyOptions> optionsAccessor,
            IOptionsMonitor<MyOptionsWithDelegateConfig> optionsAccessorWithDelegateConfig,
            IOptionsMonitor<MySubOptions> subOptionsAccessor,
            IOptionsSnapshot<MyOptions> snapshotOptionsAccessor,
            IOptionsSnapshot<MyOptions> namedOptionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _optionsWithDelegateConfig = optionsAccessorWithDelegateConfig.CurrentValue;
            _subOptions = subOptionsAccessor.CurrentValue;
            _snapshotOptions = snapshotOptionsAccessor.Value;
            _named_options_1 = namedOptionsAccessor.Get("named_options_1");
            _named_options_2 = namedOptionsAccessor.Get("named_options_2");
        }
        // </snippet2>

        public string SimpleOptions { get; private set; }
        public string SimpleOptionsWithDelegateConfig { get; private set; }
        public string SubOptions { get; private set; }
        public MyOptions MyOptions { get; private set; }
        public string SnapshotOptions { get; private set; }
        public string NamedOptions { get; private set; }

        public void OnGetAsync()
        {
            // <snippet_Example1>
            // Example #1: Simple options
            var option1 = _options.Option1;
            var option2 = _options.Option2;
            SimpleOptions = $"option1 = {option1}, option2 = {option2}";
            // </snippet_Example1>

            // <snippet_Example2>
            // Example #2: Options configured by delegate
            var delegate_config_option1 = _optionsWithDelegateConfig.Option1;
            var delegate_config_option2 = _optionsWithDelegateConfig.Option2;
            SimpleOptionsWithDelegateConfig =
                $"delegate_option1 = {delegate_config_option1}, " +
                $"delegate_option2 = {delegate_config_option2}";
            // </snippet_Example2>

            // <snippet_Example3>
            // Example #3: Suboptions
            var subOption1 = _subOptions.SubOption1;
            var subOption2 = _subOptions.SubOption2;
            SubOptions = $"subOption1 = {subOption1}, subOption2 = {subOption2}";
            // </snippet_Example3>

            // <snippet_Example4>
            // Example #4: Bind options directly to the page
            MyOptions = _options;
            // </snippet_Example4>

            // <snippet_Example5>
            // Example #5: Snapshot options
            var snapshotOption1 = _snapshotOptions.Option1;
            var snapshotOption2 = _snapshotOptions.Option2;
            SnapshotOptions =
                $"snapshot option1 = {snapshotOption1}, " +
                $"snapshot option2 = {snapshotOption2}";
            // </snippet_Example5>

            // <snippet_Example6>
            // Example #6: Named options
            var named_options_1 =
                $"named_options_1: option1 = {_named_options_1.Option1}, " +
                $"option2 = {_named_options_1.Option2}";
            var named_options_2 =
                $"named_options_2: option1 = {_named_options_2.Option1}, " +
                $"option2 = {_named_options_2.Option2}";
            NamedOptions = $"{named_options_1} {named_options_2}";
            // </snippet_Example6>
        }
    }
}

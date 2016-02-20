using Microsoft.AspNet.Mvc.Localization;

namespace Localization.StarterWeb.Services
{
    public class LocService
    {
        private readonly IHtmlLocalizer<SharedResource> _localizer;

        public LocService(IHtmlLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public LocalizedHtmlString GetLocalizedHtmlString(string key) {
            return _localizer[key];
        }
    }
}

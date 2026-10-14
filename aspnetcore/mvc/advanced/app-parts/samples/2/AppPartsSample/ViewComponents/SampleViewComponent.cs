using Microsoft.AspNetCore.Mvc;

namespace AppPartsSample.ViewComponents
{
    public class SampleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() =>
            View();
    }
}

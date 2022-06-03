using SampleApp.Filters;

namespace SampleApp.Pages.OtherPages;

[ReplaceRouteValueFilter]
public class Page3Model : BaseModel
{
    public Page3Model(ILogger<BaseModel> logger) : base(logger)
    {
    }

    public void OnGet()
    {
        SetTemplateData("Page1");
    }
}

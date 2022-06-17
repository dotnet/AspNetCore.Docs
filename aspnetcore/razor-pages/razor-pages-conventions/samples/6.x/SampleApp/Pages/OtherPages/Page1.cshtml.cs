namespace SampleApp.Pages.OtherPages;

public class Page1Model : BaseModel
{
    public Page1Model(ILogger<BaseModel> logger) : base(logger)
    {
    }

    public void OnGet()
    {
        SetTemplateData("Page1");
    }
}

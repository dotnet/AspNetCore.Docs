namespace SampleApp.Pages.OtherPages;

public class Page2Model : BaseModel
{
    public Page2Model(ILogger<BaseModel> logger) : base(logger)
    {
    }
    
    public void OnGet()
    {
        SetTemplateData("Page2");
    }
}

using Microsoft.AspNetCore.Mvc.Razor;

// Doesn't work without <TModel>
public abstract class CustomRazorPage2 : RazorPage
{
    public string CustomText { get; } = "CustomRazorPage2.";
}

using Microsoft.AspNetCore.Components;

namespace BlazorWebAssemblySample.UIInterfaces
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}

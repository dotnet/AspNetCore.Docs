using Microsoft.AspNetCore.Components;

namespace BlazorServerSample.UIInterfaces
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}

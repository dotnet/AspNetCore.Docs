using Microsoft.AspNetCore.Components;

namespace RazorComponents.UIInterfaces
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}

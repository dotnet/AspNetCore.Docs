using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers;

public class FilterFactoryController : Controller
{
    // <snippet_Index>
    [ResponseHeaderFilterFactory]
    public IActionResult Index() =>
        Content($"- {nameof(FilterFactoryController)}.{nameof(Index)}");
    // </snippet_Index>

    // <snippet_TypeFilterAttribute>
    [SampleActionTypeFilter]
    public IActionResult WithDirectAttribute() =>
        Content($"- {nameof(FilterFactoryController)}.{nameof(WithDirectAttribute)}");

    [TypeFilter(typeof(SampleActionTypeFilterAttribute))]
    public IActionResult WithTypeFilterAttribute() =>
        Content($"- {nameof(FilterFactoryController)}.{nameof(WithTypeFilterAttribute)}");

    [ServiceFilter(typeof(SampleActionTypeFilterAttribute))]
    public IActionResult WithServiceFilterAttribute() =>
        Content($"- {nameof(FilterFactoryController)}.{nameof(WithServiceFilterAttribute)}");
    // </snippet_TypeFilterAttribute>
}
// </snippet_Class>

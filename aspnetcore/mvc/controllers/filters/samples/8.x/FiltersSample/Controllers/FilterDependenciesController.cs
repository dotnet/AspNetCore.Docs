using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers;

public class FilterDependenciesController : Controller
{
    // <snippet_ServiceFilter>
    [ServiceFilter<LoggingResponseHeaderFilterService>]
    public IActionResult WithServiceFilter() =>
        Content($"- {nameof(FilterDependenciesController)}.{nameof(WithServiceFilter)}");
    // </snippet_ServiceFilter>

    // <snippet_TypeFilter>
    [TypeFilter(typeof(LoggingResponseHeaderFilter),
        Arguments = new object[] { "Filter-Header", "Filter Value" })]
    public IActionResult WithTypeFilter() =>
        Content($"- {nameof(FilterDependenciesController)}.{nameof(WithTypeFilter)}");
    // </snippet_TypeFilter>
}

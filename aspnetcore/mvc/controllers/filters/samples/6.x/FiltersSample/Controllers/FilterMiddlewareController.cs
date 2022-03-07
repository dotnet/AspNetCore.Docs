﻿using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers;

// <snippet_Class>
[MiddlewareFilter(typeof(FilterMiddlewarePipeline))]
public class FilterMiddlewareController : Controller
{
    public IActionResult Index() =>
        Content($"- {nameof(FilterMiddlewareController)}.{nameof(Index)}");
}
// </snippet_Class>

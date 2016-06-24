

MvcCoreDiagnosticSourceExtensions Class
=======================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcCoreDiagnosticSourceExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterAction(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public static void AfterAction(this DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, HttpContext httpContext, RouteData routeData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterActionMethod(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object, Microsoft.AspNetCore.Mvc.IActionResult)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type actionArguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type controller: System.Object
    
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public static void AfterActionMethod(this DiagnosticSource diagnosticSource, ActionContext actionContext, IDictionary<string, object> actionArguments, object controller, IActionResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterActionResult(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.IActionResult)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public static void AfterActionResult(this DiagnosticSource diagnosticSource, ActionContext actionContext, IActionResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnActionExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnActionExecuted(this DiagnosticSource diagnosticSource, ActionExecutedContext actionExecutedContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnActionExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnActionExecuting(this DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnActionExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnActionExecution(this DiagnosticSource diagnosticSource, ActionExecutedContext actionExecutedContext, IAsyncActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnAuthorization(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnAuthorization(this DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnAuthorizationAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnAuthorizationAsync(this DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAsyncAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnException(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnException(this DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnExceptionAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnExceptionAsync(this DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IAsyncExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResourceExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResourceExecuted(this DiagnosticSource diagnosticSource, ResourceExecutedContext resourceExecutedContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResourceExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResourceExecuting(this DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResourceExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResourceExecution(this DiagnosticSource diagnosticSource, ResourceExecutedContext resourceExecutedContext, IAsyncResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResultExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResultExecuted(this DiagnosticSource diagnosticSource, ResultExecutedContext resultExecutedContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResultExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResultExecuting(this DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResultExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResultExecution(this DiagnosticSource diagnosticSource, ResultExecutedContext resultExecutedContext, IAsyncResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeAction(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public static void BeforeAction(this DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, HttpContext httpContext, RouteData routeData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeActionMethod(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type actionArguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public static void BeforeActionMethod(this DiagnosticSource diagnosticSource, ActionContext actionContext, IDictionary<string, object> actionArguments, object controller)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeActionResult(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.IActionResult)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public static void BeforeActionResult(this DiagnosticSource diagnosticSource, ActionContext actionContext, IActionResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnActionExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnActionExecuted(this DiagnosticSource diagnosticSource, ActionExecutedContext actionExecutedContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnActionExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnActionExecuting(this DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnActionExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnActionExecution(this DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IAsyncActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnAuthorization(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnAuthorization(this DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnAuthorizationAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnAuthorizationAsync(this DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAsyncAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnException(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnException(this DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnExceptionAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnExceptionAsync(this DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IAsyncExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResourceExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResourceExecuted(this DiagnosticSource diagnosticSource, ResourceExecutedContext resourceExecutedContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResourceExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResourceExecuting(this DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResourceExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResourceExecution(this DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IAsyncResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResultExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResultExecuted(this DiagnosticSource diagnosticSource, ResultExecutedContext resultExecutedContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResultExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResultExecuting(this DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResultExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResultExecution(this DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IAsyncResultFilter filter)
    


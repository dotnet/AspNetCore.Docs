

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
    
            public static void AfterAction(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, HttpContext httpContext, RouteData routeData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterActionMethod(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object, Microsoft.AspNetCore.Mvc.IActionResult)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type actionArguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type controller: System.Object
    
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public static void AfterActionMethod(DiagnosticSource diagnosticSource, ActionContext actionContext, IDictionary<string, object> actionArguments, object controller, IActionResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterActionResult(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.IActionResult)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public static void AfterActionResult(DiagnosticSource diagnosticSource, ActionContext actionContext, IActionResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnActionExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type actionExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnActionExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ActionExecutedContext actionExecutedContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnActionExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnActionExecuting(DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnActionExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type actionExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnActionExecution(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ActionExecutedContext actionExecutedContext, IAsyncActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnAuthorization(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnAuthorization(DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnAuthorizationAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnAuthorizationAsync(DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAsyncAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnException(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnException(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnExceptionAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnExceptionAsync(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IAsyncExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResourceExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type resourceExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResourceExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResourceExecutedContext resourceExecutedContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResourceExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResourceExecuting(DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResourceExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type resourceExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResourceExecution(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResourceExecutedContext resourceExecutedContext, IAsyncResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResultExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type resultExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResultExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResultExecutedContext resultExecutedContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResultExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResultExecuting(DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.AfterOnResultExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type resultExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    
        
        .. code-block:: csharp
    
            public static void AfterOnResultExecution(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResultExecutedContext resultExecutedContext, IAsyncResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeAction(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public static void BeforeAction(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, HttpContext httpContext, RouteData routeData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeActionMethod(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type actionArguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public static void BeforeActionMethod(DiagnosticSource diagnosticSource, ActionContext actionContext, IDictionary<string, object> actionArguments, object controller)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeActionResult(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.IActionResult)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public static void BeforeActionResult(DiagnosticSource diagnosticSource, ActionContext actionContext, IActionResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnActionExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type actionExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnActionExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ActionExecutedContext actionExecutedContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnActionExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnActionExecuting(DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnActionExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnActionExecution(DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IAsyncActionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnAuthorization(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnAuthorization(DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnAuthorizationAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type authorizationContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnAuthorizationAsync(DiagnosticSource diagnosticSource, AuthorizationFilterContext authorizationContext, IAsyncAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnException(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnException(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnExceptionAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ExceptionContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type exceptionContext: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnExceptionAsync(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IAsyncExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResourceExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type resourceExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResourceExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResourceExecutedContext resourceExecutedContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResourceExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResourceExecuting(DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResourceExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resourceExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResourceExecution(DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IAsyncResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResultExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :type resultExecutedContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResultExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResultExecutedContext resultExecutedContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResultExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResultExecuting(DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreDiagnosticSourceExtensions.BeforeOnResultExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter)
    
        
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type resultExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    
        
        .. code-block:: csharp
    
            public static void BeforeOnResultExecution(DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IAsyncResultFilter filter)
    


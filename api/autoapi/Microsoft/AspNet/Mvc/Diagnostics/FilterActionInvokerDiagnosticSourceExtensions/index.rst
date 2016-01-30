

FilterActionInvokerDiagnosticSourceExtensions Class
===================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions`








Syntax
------

.. code-block:: csharp

   public class FilterActionInvokerDiagnosticSourceExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/DiagnosticSource/FilterActionInvokerDiagnosticSourceExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterActionMethod(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object, Microsoft.AspNet.Mvc.IActionResult)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type actionArguments: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type controller: System.Object
        
        
        :type result: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public static void AfterActionMethod(DiagnosticSource diagnosticSource, ActionContext actionContext, IDictionary<string, object> actionArguments, object controller, IActionResult result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterActionResult(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.IActionResult)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type result: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public static void AfterActionResult(DiagnosticSource diagnosticSource, ActionContext actionContext, IActionResult result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnActionExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ActionExecutedContext, Microsoft.AspNet.Mvc.Filters.IActionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type actionExecutedContext: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnActionExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ActionExecutedContext actionExecutedContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnActionExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.IActionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionExecutingContext: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnActionExecuting(DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnActionExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ActionExecutedContext, Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type actionExecutedContext: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnActionExecution(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ActionExecutedContext actionExecutedContext, IAsyncActionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnAuthorization(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.AuthorizationContext, Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type authorizationContext: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnAuthorization(DiagnosticSource diagnosticSource, AuthorizationContext authorizationContext, IAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnAuthorizationAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.AuthorizationContext, Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type authorizationContext: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnAuthorizationAsync(DiagnosticSource diagnosticSource, AuthorizationContext authorizationContext, IAsyncAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnException(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ExceptionContext, Microsoft.AspNet.Mvc.Filters.IExceptionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type exceptionContext: Microsoft.AspNet.Mvc.Filters.ExceptionContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IExceptionFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnException(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnExceptionAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ExceptionContext, Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type exceptionContext: Microsoft.AspNet.Mvc.Filters.ExceptionContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnExceptionAsync(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IAsyncExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnResourceExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNet.Mvc.Filters.IResourceFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type resourceExecutedContext: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnResourceExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResourceExecutedContext resourceExecutedContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnResourceExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNet.Mvc.Filters.IResourceFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type resourceExecutingContext: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnResourceExecuting(DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnResourceExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type resourceExecutedContext: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnResourceExecution(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResourceExecutedContext resourceExecutedContext, IAsyncResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnResultExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ResultExecutedContext, Microsoft.AspNet.Mvc.Filters.IResultFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type resultExecutedContext: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnResultExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResultExecutedContext resultExecutedContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnResultExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.IResultFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type resultExecutingContext: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnResultExecuting(DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.AfterOnResultExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ResultExecutedContext, Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type resultExecutedContext: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter
    
        
        .. code-block:: csharp
    
           public static void AfterOnResultExecution(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResultExecutedContext resultExecutedContext, IAsyncResultFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeActionMethod(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type actionArguments: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public static void BeforeActionMethod(DiagnosticSource diagnosticSource, ActionContext actionContext, IDictionary<string, object> actionArguments, object controller)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeActionResult(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.IActionResult)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type result: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public static void BeforeActionResult(DiagnosticSource diagnosticSource, ActionContext actionContext, IActionResult result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnActionExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ActionExecutedContext, Microsoft.AspNet.Mvc.Filters.IActionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type actionExecutedContext: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnActionExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ActionExecutedContext actionExecutedContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnActionExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.IActionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionExecutingContext: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IActionFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnActionExecuting(DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IActionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnActionExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionExecutingContext: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnActionExecution(DiagnosticSource diagnosticSource, ActionExecutingContext actionExecutingContext, IAsyncActionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnAuthorization(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.AuthorizationContext, Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type authorizationContext: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnAuthorization(DiagnosticSource diagnosticSource, AuthorizationContext authorizationContext, IAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnAuthorizationAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.AuthorizationContext, Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type authorizationContext: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnAuthorizationAsync(DiagnosticSource diagnosticSource, AuthorizationContext authorizationContext, IAsyncAuthorizationFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnException(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ExceptionContext, Microsoft.AspNet.Mvc.Filters.IExceptionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type exceptionContext: Microsoft.AspNet.Mvc.Filters.ExceptionContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IExceptionFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnException(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnExceptionAsync(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ExceptionContext, Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type exceptionContext: Microsoft.AspNet.Mvc.Filters.ExceptionContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnExceptionAsync(DiagnosticSource diagnosticSource, ExceptionContext exceptionContext, IAsyncExceptionFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnResourceExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext, Microsoft.AspNet.Mvc.Filters.IResourceFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type resourceExecutedContext: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnResourceExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResourceExecutedContext resourceExecutedContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnResourceExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNet.Mvc.Filters.IResourceFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type resourceExecutingContext: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResourceFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnResourceExecuting(DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnResourceExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type resourceExecutingContext: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnResourceExecution(DiagnosticSource diagnosticSource, ResourceExecutingContext resourceExecutingContext, IAsyncResourceFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnResultExecuted(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.Filters.ResultExecutedContext, Microsoft.AspNet.Mvc.Filters.IResultFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type resultExecutedContext: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnResultExecuted(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, ResultExecutedContext resultExecutedContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnResultExecuting(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.IResultFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type resultExecutingContext: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IResultFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnResultExecuting(DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IResultFilter filter)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.FilterActionInvokerDiagnosticSourceExtensions.BeforeOnResultExecution(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type resultExecutingContext: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter
    
        
        .. code-block:: csharp
    
           public static void BeforeOnResultExecution(DiagnosticSource diagnosticSource, ResultExecutingContext resultExecutingContext, IAsyncResultFilter filter)
    


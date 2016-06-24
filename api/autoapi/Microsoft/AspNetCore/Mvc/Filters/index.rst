

Microsoft.AspNetCore.Mvc.Filters Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ActionExecutedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ActionExecutingContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ActionExecutionDelegate/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ActionFilterAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/AuthorizationFilterContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ExceptionContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ExceptionFilterAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/FilterCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/FilterContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/FilterDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/FilterItem/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/FilterProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/FilterScope/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IActionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IAsyncActionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IAsyncAuthorizationFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IAsyncExceptionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IAsyncResourceFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IAsyncResultFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IAuthorizationFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IExceptionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IFilterContainer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IFilterFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IFilterMetadata/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IFilterProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IOrderedFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IResourceFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/IResultFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResourceExecutedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResourceExecutingContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResourceExecutionDelegate/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResultExecutedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResultExecutingContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResultExecutionDelegate/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Filters/ResultFilterAttribute/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Filters


    .. rubric:: Interfaces


    interface :dn:iface:`IActionFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IActionFilter

        
        A filter that surrounds execution of the action.


    interface :dn:iface:`IAsyncActionFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter

        
        A filter that asynchronously surrounds execution of the action, after model binding is complete.


    interface :dn:iface:`IAsyncAuthorizationFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter

        
        A filter that asynchronously confirms request authorization.


    interface :dn:iface:`IAsyncExceptionFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter

        
        A filter that runs asynchronously after an action has thrown an :any:`System.Exception`\.


    interface :dn:iface:`IAsyncResourceFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter

        
        A filter that asynchronously surrounds execution of model binding, the action (and filters) and the action
        result (and filters).


    interface :dn:iface:`IAsyncResultFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter

        
        A filter that asynchronously surrounds execution of the action result.


    interface :dn:iface:`IAuthorizationFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter

        
        A filter that confirms request authorization.


    interface :dn:iface:`IExceptionFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter

        
        A filter that runs after an action has thrown an :any:`System.Exception`\.


    interface :dn:iface:`IFilterContainer`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IFilterContainer

        
        A filter that requires a reference back to the :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterFactory` that created it.


    interface :dn:iface:`IFilterFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IFilterFactory

        
        An interface for filter metadata which can create an instance of an executable filter.


    interface :dn:iface:`IFilterMetadata`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata

        
        Marker interface for filters handled in the MVC request pipeline.


    interface :dn:iface:`IFilterProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IFilterProvider

        
        A :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem` provider. Implementations should update :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.Results`
        to make executable filters available.


    interface :dn:iface:`IOrderedFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter

        
        A filter that specifies the relative order it should run.


    interface :dn:iface:`IResourceFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IResourceFilter

        
        A filter that surrounds execution of model binding, the action (and filters) and the action result
        (and filters).


    interface :dn:iface:`IResultFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Filters.IResultFilter

        
        A filter that surrounds execution of the action result.


    .. rubric:: Classes


    class :dn:cls:`ActionExecutedContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext

        
        A context for action filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)` calls.


    class :dn:cls:`ActionExecutingContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext

        
        A context for action filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)` and 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` calls.


    class :dn:cls:`ActionFilterAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute

        
        An abstract filter that asynchronously surrounds execution of the action and the action result. Subclasses
        should override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)`\, :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)` or 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` but not :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` and either of the other two.
        Similarly subclasses should override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)`\, :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)` or 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` but not :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` and either of the other two.


    class :dn:cls:`AuthorizationFilterContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext

        
        A context for authorization filters i.e. :any:`Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter` and 
        :any:`Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter` implementations.


    class :dn:cls:`ExceptionContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ExceptionContext

        
        A context for exception filters i.e. :any:`Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter` and 
        :any:`Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter` implementations.


    class :dn:cls:`ExceptionFilterAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute

        
        An abstract filter that runs asynchronously after an action has thrown an :any:`System.Exception`\. Subclasses
        must override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)` or :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.OnExceptionAsync(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)` but not both.


    class :dn:cls:`FilterCollection`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.FilterCollection

        


    class :dn:cls:`FilterContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.FilterContext

        
        An abstract context for filters.


    class :dn:cls:`FilterDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor

        
        Descriptor for an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.


    class :dn:cls:`FilterItem`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.FilterItem

        
        Used to associate executable filters with :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` instances
        as part of :any:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext`\. An :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider` should
        inspect :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.Results` and set :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.Filter` and 
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.IsReusable` as appropriate.


    class :dn:cls:`FilterProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext

        
        A context for filter providers i.e. :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider` implementations.


    class :dn:cls:`FilterScope`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.FilterScope

        
        <p>
        Contains constant values for known filter scopes.
        </p>
        <p>
        Scope defines the ordering of filters that have the same order. Scope is by-default
        defined by how a filter is registered.
        </p>


    class :dn:cls:`ResourceExecutedContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext

        
        A context for resource filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)` calls.


    class :dn:cls:`ResourceExecutingContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext

        
        A context for resource filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)` and 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter.OnResourceExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate)` calls.


    class :dn:cls:`ResultExecutedContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext

        
        A context for result filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)` calls.


    class :dn:cls:`ResultExecutingContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext

        
        A context for result filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)` and 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` calls.


    class :dn:cls:`ResultFilterAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute

        
        An abstract filter that asynchronously surrounds execution of the action result. Subclasses
        must override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)`\, :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)` or 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` but not :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` and either of the other two.


    .. rubric:: Delegates


    delegate :dn:del:`ActionExecutionDelegate`
        .. object: type=delegate name=Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate

        
        A delegate that asynchronously returns an :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext` indicating the action or the next
        action filter has executed.


    delegate :dn:del:`ResourceExecutionDelegate`
        .. object: type=delegate name=Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate

        
        A delegate that asynchronously returns a :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext` indicating model binding, the
        action, the action's result, result filters, and exception filters have executed.


    delegate :dn:del:`ResultExecutionDelegate`
        .. object: type=delegate name=Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate

        
        A delegate that asynchronously returns an :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext` indicating the action result or
        the next result filter has executed.



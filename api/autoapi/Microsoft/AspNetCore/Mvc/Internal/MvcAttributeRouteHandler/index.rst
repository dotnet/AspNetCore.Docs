

MvcAttributeRouteHandler Class
==============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler`








Syntax
------

.. code-block:: csharp

    public class MvcAttributeRouteHandler : IRouter








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler.MvcAttributeRouteHandler(Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory, Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type actionInvokerFactory: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory
    
        
        :type actionSelector: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public MvcAttributeRouteHandler(IActionInvokerFactory actionInvokerFactory, IActionSelector actionSelector, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler.MvcAttributeRouteHandler(Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory, Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor)
    
        
    
        
        :type actionInvokerFactory: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory
    
        
        :type actionSelector: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type actionContextAccessor: Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor
    
        
        .. code-block:: csharp
    
            public MvcAttributeRouteHandler(IActionInvokerFactory actionInvokerFactory, IActionSelector actionSelector, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory, IActionContextAccessor actionContextAccessor)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler.Actions
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>[]
    
        
        .. code-block:: csharp
    
            public ActionDescriptor[] Actions { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcAttributeRouteHandler.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RouteAsync(RouteContext context)
    




MvcRouteHandler Class
=====================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler`








Syntax
------

.. code-block:: csharp

    public class MvcRouteHandler : IRouter








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.MvcRouteHandler(Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory, Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type actionInvokerFactory: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory
    
        
        :type actionSelector: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public MvcRouteHandler(IActionInvokerFactory actionInvokerFactory, IActionSelector actionSelector, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.MvcRouteHandler(Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory, Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor)
    
        
    
        
        :type actionInvokerFactory: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory
    
        
        :type actionSelector: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type actionContextAccessor: Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor
    
        
        .. code-block:: csharp
    
            public MvcRouteHandler(IActionInvokerFactory actionInvokerFactory, IActionSelector actionSelector, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory, IActionContextAccessor actionContextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RouteAsync(RouteContext context)
    




ControllerActionInvokerProvider Class
=====================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider`








Syntax
------

.. code-block:: csharp

    public class ControllerActionInvokerProvider : IActionInvokerProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider.ControllerActionInvokerProvider(Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory, Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache, Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>, Microsoft.Extensions.Logging.ILoggerFactory, System.Diagnostics.DiagnosticSource)
    
        
    
        
        :type controllerFactory: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory
    
        
        :type controllerActionInvokerCache: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    
        
        :type argumentBinder: Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder
    
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
            public ControllerActionInvokerProvider(IControllerFactory controllerFactory, ControllerActionInvokerCache controllerActionInvokerCache, IControllerActionArgumentBinder argumentBinder, IOptions<MvcOptions> optionsAccessor, ILoggerFactory loggerFactory, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuted(ActionInvokerProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuting(ActionInvokerProviderContext context)
    


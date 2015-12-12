

ControllerActionInvokerProvider Class
=====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider`








Syntax
------

.. code-block:: csharp

   public class ControllerActionInvokerProvider : IActionInvokerProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/ControllerActionInvokerProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider.ControllerActionInvokerProvider(Microsoft.AspNet.Mvc.Controllers.IControllerFactory, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Filters.IFilterProvider>, Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcOptions>, Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor, Microsoft.Extensions.Logging.ILoggerFactory, System.Diagnostics.DiagnosticSource)
    
        
        
        
        :type controllerFactory: Microsoft.AspNet.Mvc.Controllers.IControllerFactory
        
        
        :type filterProviders: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Filters.IFilterProvider}
        
        
        :type argumentBinder: Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcOptions}
        
        
        :type actionBindingContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
           public ControllerActionInvokerProvider(IControllerFactory controllerFactory, IEnumerable<IFilterProvider> filterProviders, IControllerActionArgumentBinder argumentBinder, IOptions<MvcOptions> optionsAccessor, IActionBindingContextAccessor actionBindingContextAccessor, ILoggerFactory loggerFactory, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(ActionInvokerProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(ActionInvokerProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    


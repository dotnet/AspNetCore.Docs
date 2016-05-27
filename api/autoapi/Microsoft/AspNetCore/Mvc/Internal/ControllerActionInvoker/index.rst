

ControllerActionInvoker Class
=============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker`








Syntax
------

.. code-block:: csharp

    public class ControllerActionInvoker : FilterActionInvoker, IActionInvoker








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.ControllerActionInvoker(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache, Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory, Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>, Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>, Microsoft.Extensions.Logging.ILogger, System.Diagnostics.DiagnosticSource, System.Int32)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type controllerActionInvokerCache: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    
        
        :type controllerFactory: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory
    
        
        :type descriptor: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
    
        
        :type inputFormatters: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>}
    
        
        :type argumentBinder: Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder
    
        
        :type modelValidatorProviders: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>}
    
        
        :type valueProviderFactories: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type maxModelValidationErrors: System.Int32
    
        
        .. code-block:: csharp
    
            public ControllerActionInvoker(ActionContext actionContext, ControllerActionInvokerCache controllerActionInvokerCache, IControllerFactory controllerFactory, ControllerActionDescriptor descriptor, IReadOnlyList<IInputFormatter> inputFormatters, IControllerActionArgumentBinder argumentBinder, IReadOnlyList<IModelValidatorProvider> modelValidatorProviders, IReadOnlyList<IValueProviderFactory> valueProviderFactories, ILogger logger, DiagnosticSource diagnosticSource, int maxModelValidationErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.BindActionArgumentsAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            protected override Task<IDictionary<string, object>> BindActionArgumentsAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.CreateInstance()
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            protected override object CreateInstance()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.InvokeActionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.IActionResult<Microsoft.AspNetCore.Mvc.IActionResult>}
    
        
        .. code-block:: csharp
    
            protected override Task<IActionResult> InvokeActionAsync(ActionExecutingContext actionExecutingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.ReleaseInstance(System.Object)
    
        
    
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
            protected override void ReleaseInstance(object instance)
    


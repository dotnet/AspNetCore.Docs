

ControllerActionInvoker Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker`








Syntax
------

.. code-block:: csharp

   public class ControllerActionInvoker : FilterActionInvoker, IActionInvoker





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/ControllerActionInvoker.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker.ControllerActionInvoker(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Filters.IFilterProvider>, Microsoft.AspNet.Mvc.Controllers.IControllerFactory, Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Formatters.IOutputFormatter>, Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ModelBinding.IModelBinder>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory>, Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor, Microsoft.Extensions.Logging.ILogger, System.Diagnostics.DiagnosticSource, System.Int32)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filterProviders: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Filters.IFilterProvider}
        
        
        :type controllerFactory: Microsoft.AspNet.Mvc.Controllers.IControllerFactory
        
        
        :type descriptor: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor
        
        
        :type inputFormatters: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :type outputFormatters: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
        
        
        :type controllerActionArgumentBinder: Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder
        
        
        :type modelBinders: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.IModelBinder}
        
        
        :type modelValidatorProviders: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider}
        
        
        :type valueProviderFactories: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory}
        
        
        :type actionBindingContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type maxModelValidationErrors: System.Int32
    
        
        .. code-block:: csharp
    
           public ControllerActionInvoker(ActionContext actionContext, IReadOnlyList<IFilterProvider> filterProviders, IControllerFactory controllerFactory, ControllerActionDescriptor descriptor, IReadOnlyList<IInputFormatter> inputFormatters, IReadOnlyList<IOutputFormatter> outputFormatters, IControllerActionArgumentBinder controllerActionArgumentBinder, IReadOnlyList<IModelBinder> modelBinders, IReadOnlyList<IModelValidatorProvider> modelValidatorProviders, IReadOnlyList<IValueProviderFactory> valueProviderFactories, IActionBindingContextAccessor actionBindingContextAccessor, ILogger logger, DiagnosticSource diagnosticSource, int maxModelValidationErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker.BindActionArgumentsAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ActionBindingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ActionBindingContext
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IDictionary{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           protected override Task<IDictionary<string, object>> BindActionArgumentsAsync(ActionContext context, ActionBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker.CreateInstance()
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected override object CreateInstance()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker.InvokeActionAsync(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
        
        
        :type actionExecutingContext: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.IActionResult}
    
        
        .. code-block:: csharp
    
           protected override Task<IActionResult> InvokeActionAsync(ActionExecutingContext actionExecutingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker.ReleaseInstance(System.Object)
    
        
        
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
           protected override void ReleaseInstance(object instance)
    


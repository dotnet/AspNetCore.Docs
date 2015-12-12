

FilterActionInvoker Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker`








Syntax
------

.. code-block:: csharp

   public abstract class FilterActionInvoker : IActionInvoker





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/FilterActionInvoker.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.FilterActionInvoker(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Filters.IFilterProvider>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Formatters.IOutputFormatter>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ModelBinding.IModelBinder>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory>, Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor, Microsoft.Extensions.Logging.ILogger, System.Diagnostics.DiagnosticSource, System.Int32)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filterProviders: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Filters.IFilterProvider}
        
        
        :type inputFormatters: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :type outputFormatters: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
        
        
        :type modelBinders: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.IModelBinder}
        
        
        :type modelValidatorProviders: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider}
        
        
        :type valueProviderFactories: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory}
        
        
        :type actionBindingContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type maxModelValidationErrors: System.Int32
    
        
        .. code-block:: csharp
    
           public FilterActionInvoker(ActionContext actionContext, IReadOnlyList<IFilterProvider> filterProviders, IReadOnlyList<IInputFormatter> inputFormatters, IReadOnlyList<IOutputFormatter> outputFormatters, IReadOnlyList<IModelBinder> modelBinders, IReadOnlyList<IModelValidatorProvider> modelValidatorProviders, IReadOnlyList<IValueProviderFactory> valueProviderFactories, IActionBindingContextAccessor actionBindingContextAccessor, ILogger logger, DiagnosticSource diagnosticSource, int maxModelValidationErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.BindActionArgumentsAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ActionBindingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ActionBindingContext
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IDictionary{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           protected abstract Task<IDictionary<string, object>> BindActionArgumentsAsync(ActionContext context, ActionBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.CreateInstance()
    
        
    
        Called to create an instance of an object which will act as the reciever of the action invocation.
    
        
        :rtype: System.Object
        :return: The constructed instance or <c>null</c>.
    
        
        .. code-block:: csharp
    
           protected abstract object CreateInstance()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.InvokeActionAsync(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
        
        
        :type actionExecutingContext: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.IActionResult}
    
        
        .. code-block:: csharp
    
           protected abstract Task<IActionResult> InvokeActionAsync(ActionExecutingContext actionExecutingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.InvokeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task InvokeAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.ReleaseInstance(System.Object)
    
        
    
        Called to create an instance of an object which will act as the reciever of the action invocation.
    
        
        
        
        :param instance: The instance to release.
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
           protected abstract void ReleaseInstance(object instance)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.ActionBindingContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionBindingContext
    
        
        .. code-block:: csharp
    
           protected ActionBindingContext ActionBindingContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.ActionContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           protected ActionContext ActionContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.Instance
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected object Instance { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected ILogger Logger { get; }
    


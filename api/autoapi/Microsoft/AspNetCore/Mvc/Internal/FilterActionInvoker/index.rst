

FilterActionInvoker Class
=========================





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








Syntax
------

.. code-block:: csharp

    public abstract class FilterActionInvoker : IActionInvoker








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.Context
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        .. code-block:: csharp
    
            protected ControllerContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.Instance
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            protected object Instance
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.FilterActionInvoker(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>, Microsoft.Extensions.Logging.ILogger, System.Diagnostics.DiagnosticSource, System.Int32)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type controllerActionInvokerCache: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    
        
        :type inputFormatters: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>}
    
        
        :type modelValidatorProviders: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>}
    
        
        :type valueProviderFactories: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type maxModelValidationErrors: System.Int32
    
        
        .. code-block:: csharp
    
            public FilterActionInvoker(ActionContext actionContext, ControllerActionInvokerCache controllerActionInvokerCache, IReadOnlyList<IInputFormatter> inputFormatters, IReadOnlyList<IModelValidatorProvider> modelValidatorProviders, IReadOnlyList<IValueProviderFactory> valueProviderFactories, ILogger logger, DiagnosticSource diagnosticSource, int maxModelValidationErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.BindActionArgumentsAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            protected abstract Task<IDictionary<string, object>> BindActionArgumentsAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.CreateInstance()
    
        
    
        
        Called to create an instance of an object which will act as the reciever of the action invocation.
    
        
        :rtype: System.Object
        :return: The constructed instance or <code>null</code>.
    
        
        .. code-block:: csharp
    
            protected abstract object CreateInstance()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.GetControllerActionMethodExecutor()
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    
        
        .. code-block:: csharp
    
            protected ObjectMethodExecutor GetControllerActionMethodExecutor()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.InvokeActionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        :type actionExecutingContext: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.IActionResult<Microsoft.AspNetCore.Mvc.IActionResult>}
    
        
        .. code-block:: csharp
    
            protected abstract Task<IActionResult> InvokeActionAsync(ActionExecutingContext actionExecutingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.InvokeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task InvokeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterActionInvoker.ReleaseInstance(System.Object)
    
        
    
        
        Called to create an instance of an object which will act as the reciever of the action invocation.
    
        
    
        
        :param instance: The instance to release.
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
            protected abstract void ReleaseInstance(object instance)
    


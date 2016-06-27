

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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker`








Syntax
------

.. code-block:: csharp

    public class ControllerActionInvoker : IActionInvoker








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.ControllerActionInvoker(Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache, Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory, Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder, Microsoft.Extensions.Logging.ILogger, System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>, System.Int32)
    
        
    
        
        :type cache: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    
        
        :type controllerFactory: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory
    
        
        :type controllerArgumentBinder: Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type valueProviderFactories: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        :type maxModelValidationErrors: System.Int32
    
        
        .. code-block:: csharp
    
            public ControllerActionInvoker(ControllerActionInvokerCache cache, IControllerFactory controllerFactory, IControllerArgumentBinder controllerArgumentBinder, ILogger logger, DiagnosticSource diagnosticSource, ActionContext actionContext, IReadOnlyList<IValueProviderFactory> valueProviderFactories, int maxModelValidationErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.InvokeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task InvokeAsync()
    


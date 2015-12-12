

DefaultViewComponentInvoker Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentInvoker : IViewComponentInvoker





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/DefaultViewComponentInvoker.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker.DefaultViewComponentInvoker(Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache, Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type typeActivatorCache: Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache
        
        
        :type viewComponentActivator: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public DefaultViewComponentInvoker(ITypeActivatorCache typeActivatorCache, IViewComponentActivator viewComponentActivator, DiagnosticSource diagnosticSource, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker.Invoke(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           public void Invoke(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker.InvokeAsync(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task InvokeAsync(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker.InvokeSyncCore(System.Reflection.MethodInfo, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type method: System.Reflection.MethodInfo
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: Microsoft.AspNet.Mvc.IViewComponentResult
    
        
        .. code-block:: csharp
    
           public IViewComponentResult InvokeSyncCore(MethodInfo method, ViewComponentContext context)
    


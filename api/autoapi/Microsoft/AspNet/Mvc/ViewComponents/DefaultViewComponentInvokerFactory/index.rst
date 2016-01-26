

DefaultViewComponentInvokerFactory Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentInvokerFactory : IViewComponentInvokerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/DefaultViewComponentInvokerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory.DefaultViewComponentInvokerFactory(Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache, Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
        
        
        :type typeActivatorCache: Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache
        
        
        :type viewComponentActivator: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public DefaultViewComponentInvokerFactory(ITypeActivatorCache typeActivatorCache, IViewComponentActivator viewComponentActivator, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory.CreateInstance(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker
    
        
        .. code-block:: csharp
    
           public IViewComponentInvoker CreateInstance(ViewComponentContext context)
    


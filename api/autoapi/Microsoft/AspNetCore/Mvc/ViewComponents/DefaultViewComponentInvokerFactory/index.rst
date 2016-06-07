

DefaultViewComponentInvokerFactory Class
========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentInvokerFactory : IViewComponentInvokerFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory.DefaultViewComponentInvokerFactory(Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentInvokerCache, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type viewComponentFactory: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory
    
        
        :type viewComponentInvokerCache: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentInvokerCache
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentInvokerFactory(IViewComponentFactory viewComponentFactory, ViewComponentInvokerCache viewComponentInvokerCache, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory.CreateInstance(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker
    
        
        .. code-block:: csharp
    
            public IViewComponentInvoker CreateInstance(ViewComponentContext context)
    


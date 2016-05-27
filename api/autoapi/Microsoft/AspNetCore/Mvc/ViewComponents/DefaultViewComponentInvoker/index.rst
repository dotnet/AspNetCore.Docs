

DefaultViewComponentInvoker Class
=================================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentInvoker : IViewComponentInvoker








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker.DefaultViewComponentInvoker(Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentInvokerCache, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker`\.
    
        
    
        
        :param viewComponentFactory: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory`\.
        
        :type viewComponentFactory: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory
    
        
        :param viewComponentInvokerCache: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentInvokerCache`\.
        
        :type viewComponentInvokerCache: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentInvokerCache
    
        
        :param diagnosticSource: The :any:`System.Diagnostics.DiagnosticSource`\.
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger`\.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentInvoker(IViewComponentFactory viewComponentFactory, ViewComponentInvokerCache viewComponentInvokerCache, DiagnosticSource diagnosticSource, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker.InvokeAsync(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task InvokeAsync(ViewComponentContext context)
    


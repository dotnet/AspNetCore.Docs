

DefaultViewComponentInvokerLoggerExtensions Class
=================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.Logging.DefaultViewComponentInvokerLoggerExtensions`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentInvokerLoggerExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Logging/DefaultViewComponentInvokerLoggerExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Logging.DefaultViewComponentInvokerLoggerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Logging.DefaultViewComponentInvokerLoggerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Logging.DefaultViewComponentInvokerLoggerExtensions.ViewComponentExecuted(Microsoft.Extensions.Logging.ILogger, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext, System.Int32, System.Object)
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        
        
        :type startTime: System.Int32
        
        
        :type result: System.Object
    
        
        .. code-block:: csharp
    
           public static void ViewComponentExecuted(ILogger logger, ViewComponentContext context, int startTime, object result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Logging.DefaultViewComponentInvokerLoggerExtensions.ViewComponentExecuting(Microsoft.Extensions.Logging.ILogger, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           public static void ViewComponentExecuting(ILogger logger, ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Logging.DefaultViewComponentInvokerLoggerExtensions.ViewComponentScope(Microsoft.Extensions.Logging.ILogger, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public static IDisposable ViewComponentScope(ILogger logger, ViewComponentContext context)
    


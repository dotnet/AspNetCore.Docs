

ControllerActionInvokerLoggerExtensions Class
=============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Logging.ControllerActionInvokerLoggerExtensions`








Syntax
------

.. code-block:: csharp

   public class ControllerActionInvokerLoggerExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Logging/ControllerActionInvokerLoggerExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Logging.ControllerActionInvokerLoggerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Logging.ControllerActionInvokerLoggerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Logging.ControllerActionInvokerLoggerExtensions.ActionMethodExecuted(Microsoft.Extensions.Logging.ILogger, Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.IActionResult)
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type result: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public static void ActionMethodExecuted(ILogger logger, ActionExecutingContext context, IActionResult result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Logging.ControllerActionInvokerLoggerExtensions.ActionMethodExecuting(Microsoft.Extensions.Logging.ILogger, Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, System.Object[])
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type arguments: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void ActionMethodExecuting(ILogger logger, ActionExecutingContext context, object[] arguments)
    


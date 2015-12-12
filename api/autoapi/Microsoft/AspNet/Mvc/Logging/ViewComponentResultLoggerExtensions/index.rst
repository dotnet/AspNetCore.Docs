

ViewComponentResultLoggerExtensions Class
=========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Logging.ViewComponentResultLoggerExtensions`








Syntax
------

.. code-block:: csharp

   public class ViewComponentResultLoggerExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Logging/ViewComponentResultLoggerExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Logging.ViewComponentResultLoggerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Logging.ViewComponentResultLoggerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Logging.ViewComponentResultLoggerExtensions.ViewComponentResultExecuting(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type viewComponentName: System.String
        
        
        :type arguments: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void ViewComponentResultExecuting(ILogger logger, string viewComponentName, object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Logging.ViewComponentResultLoggerExtensions.ViewComponentResultExecuting(Microsoft.Extensions.Logging.ILogger, System.Type, System.Object[])
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type viewComponentType: System.Type
        
        
        :type arguments: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void ViewComponentResultExecuting(ILogger logger, Type viewComponentType, object[] arguments)
    


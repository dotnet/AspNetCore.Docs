

LogFormatter Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Logging.Internal.LogFormatter`








Syntax
------

.. code-block:: csharp

   public class LogFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Logging/LogFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Logging.Internal.LogFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Logging.Internal.LogFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Logging.Internal.LogFormatter.Formatter(System.Object, System.Exception)
    
        
    
        A formatter for use with :dn:meth:`Microsoft.Extensions.Logging.ILogger.Log(Microsoft.Extensions.Logging.LogLevel,System.Int32,System.Object,System.Exception,System.Func{System.Object,System.Exception,System.String})`\.
    
        
        
        
        :type o: System.Object
        
        
        :type e: System.Exception
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Formatter(object o, Exception e)
    


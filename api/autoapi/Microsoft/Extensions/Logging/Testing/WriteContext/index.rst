

WriteContext Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.WriteContext`








Syntax
------

.. code-block:: csharp

   public class WriteContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Testing/WriteContext.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Testing.WriteContext

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.WriteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.EventId
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int EventId { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.Formatter
    
        
        :rtype: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public Func<object, Exception, string> Formatter { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.LogLevel
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           public LogLevel LogLevel { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.LoggerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string LoggerName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.Scope
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Scope { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.State
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object State { get; set; }
    


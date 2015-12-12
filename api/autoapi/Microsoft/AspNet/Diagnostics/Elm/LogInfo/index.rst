

LogInfo Class
=============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.LogInfo`








Syntax
------

.. code-block:: csharp

   public class LogInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/LogInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.LogInfo

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.LogInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.ActivityContext
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ActivityContext
    
        
        .. code-block:: csharp
    
           public ActivityContext ActivityContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.EventID
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int EventID { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.Message
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Message { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.Severity
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           public LogLevel Severity { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.State
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object State { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.LogInfo.Time
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public DateTimeOffset Time { get; set; }
    




ElmLogger Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmLogger`








Syntax
------

.. code-block:: csharp

   public class ElmLogger : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ElmLogger.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger.ElmLogger(System.String, Microsoft.AspNet.Diagnostics.Elm.ElmOptions, Microsoft.AspNet.Diagnostics.Elm.ElmStore)
    
        
        
        
        :type name: System.String
        
        
        :type options: Microsoft.AspNet.Diagnostics.Elm.ElmOptions
        
        
        :type store: Microsoft.AspNet.Diagnostics.Elm.ElmStore
    
        
        .. code-block:: csharp
    
           public ElmLogger(string name, ElmOptions options, ElmStore store)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmLogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    


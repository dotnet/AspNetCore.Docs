

WriteContext Class
==================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Testing`
Assemblies
    * Microsoft.Extensions.Logging.Testing

----

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








.. dn:class:: Microsoft.Extensions.Logging.Testing.WriteContext
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Testing.WriteContext

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.WriteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.EventId
    
        
        :rtype: Microsoft.Extensions.Logging.EventId
    
        
        .. code-block:: csharp
    
            public EventId EventId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Exception
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.Formatter
    
        
        :rtype: System.Func<System.Func`3>{System.Object<System.Object>, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<object, Exception, string> Formatter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.LogLevel
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            public LogLevel LogLevel
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.LoggerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string LoggerName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.Scope
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Scope
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.WriteContext.State
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object State
            {
                get;
                set;
            }
    


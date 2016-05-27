

IFilterLoggerSettings Interface
===============================






Filter settings for messages logged by an :any:`Microsoft.Extensions.Logging.ILogger`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Filter

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFilterLoggerSettings








.. dn:interface:: Microsoft.Extensions.Logging.IFilterLoggerSettings
    :hidden:

.. dn:interface:: Microsoft.Extensions.Logging.IFilterLoggerSettings

Properties
----------

.. dn:interface:: Microsoft.Extensions.Logging.IFilterLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.IFilterLoggerSettings.ChangeToken
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            IChangeToken ChangeToken
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.IFilterLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.IFilterLoggerSettings.Reload()
    
        
        :rtype: Microsoft.Extensions.Logging.IFilterLoggerSettings
    
        
        .. code-block:: csharp
    
            IFilterLoggerSettings Reload()
    
    .. dn:method:: Microsoft.Extensions.Logging.IFilterLoggerSettings.TryGetSwitch(System.String, out Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type name: System.String
    
        
        :type level: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool TryGetSwitch(string name, out LogLevel level)
    


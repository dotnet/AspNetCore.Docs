

FilterLoggerSettings Class
==========================






Filter settings for messages logged by an :any:`Microsoft.Extensions.Logging.ILogger`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Filter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.FilterLoggerSettings`








Syntax
------

.. code-block:: csharp

    public class FilterLoggerSettings : IFilterLoggerSettings, IEnumerable<KeyValuePair<string, LogLevel>>, IEnumerable








.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerSettings
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerSettings

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.FilterLoggerSettings.Add(System.String, Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        Adds a filter for given logger category name and :any:`Microsoft.Extensions.Logging.LogLevel`\.
    
        
    
        
        :param categoryName: The logger category name.
        
        :type categoryName: System.String
    
        
        :param logLevel: The log level.
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            public void Add(string categoryName, LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.FilterLoggerSettings.Microsoft.Extensions.Logging.IFilterLoggerSettings.Reload()
    
        
        :rtype: Microsoft.Extensions.Logging.IFilterLoggerSettings
    
        
        .. code-block:: csharp
    
            IFilterLoggerSettings IFilterLoggerSettings.Reload()
    
    .. dn:method:: Microsoft.Extensions.Logging.FilterLoggerSettings.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Logging.LogLevel>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>}}
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, LogLevel>> IEnumerable<KeyValuePair<string, LogLevel>>.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Logging.FilterLoggerSettings.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Logging.FilterLoggerSettings.TryGetSwitch(System.String, out Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type name: System.String
    
        
        :type level: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetSwitch(string name, out LogLevel level)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.FilterLoggerSettings.Microsoft.Extensions.Logging.IFilterLoggerSettings.ChangeToken
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            IChangeToken IFilterLoggerSettings.ChangeToken { get; }
    
    .. dn:property:: Microsoft.Extensions.Logging.FilterLoggerSettings.Switches
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, LogLevel> Switches { get; set; }
    


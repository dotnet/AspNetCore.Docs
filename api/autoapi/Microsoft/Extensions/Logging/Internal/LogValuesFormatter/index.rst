

LogValuesFormatter Class
========================






Formatter to convert the named format items like {NamedformatItem} to :dn:meth:`string.Format` format.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Internal`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Internal.LogValuesFormatter`








Syntax
------

.. code-block:: csharp

    public class LogValuesFormatter








.. dn:class:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.LogValuesFormatter(System.String)
    
        
    
        
        :type format: System.String
    
        
        .. code-block:: csharp
    
            public LogValuesFormatter(string format)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.Format(System.Object[])
    
        
    
        
        :type values: System.Object<System.Object>[]
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Format(object[] values)
    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.GetValue(System.Object[], System.Int32)
    
        
    
        
        :type values: System.Object<System.Object>[]
    
        
        :type index: System.Int32
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, object> GetValue(object[] values, int index)
    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.GetValues(System.Object[])
    
        
    
        
        :type values: System.Object<System.Object>[]
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            public IEnumerable<KeyValuePair<string, object>> GetValues(object[] values)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.OriginalFormat
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string OriginalFormat { get; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.ValueNames
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public List<string> ValueNames { get; }
    




LogValuesFormatter Class
========================



.. contents:: 
   :local:



Summary
-------

Formatter to convert the named format items like {NamedformatItem} to :dn:meth:`System.String.Format(System.String,System.Object)` format.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Internal.LogValuesFormatter`








Syntax
------

.. code-block:: csharp

   public class LogValuesFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/Internal/LogValuesFormatter.cs>`_





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
    
        
        
        
        :type values: System.Object[]
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Format(object[] values)
    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.LogValuesFormatter.GetValues(System.Object[])
    
        
        
        
        :type values: System.Object[]
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
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
    
        
        :rtype: System.Collections.Generic.List{System.String}
    
        
        .. code-block:: csharp
    
           public List<string> ValueNames { get; }
    


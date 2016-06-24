

FormattedLogValues Class
========================






LogValues to enable formatting options supported by :dn:meth:`string.Format`\. 
This also enables using {NamedformatItem} in the format string.


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
* :dn:cls:`Microsoft.Extensions.Logging.Internal.FormattedLogValues`








Syntax
------

.. code-block:: csharp

    public class FormattedLogValues : IReadOnlyList<KeyValuePair<string, object>>, IReadOnlyCollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable








.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.FormattedLogValues(System.String, System.Object[])
    
        
    
        
        :type format: System.String
    
        
        :type values: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public FormattedLogValues(string format, params object[] values)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, object> this[int index] { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    




IReadableStringCollection Interface
===================================



.. contents:: 
   :local:



Summary
-------

Accessors for headers, query, forms, etc.











Syntax
------

.. code-block:: csharp

   public interface IReadableStringCollection : IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/IReadableStringCollection.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IReadableStringCollection

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.IReadableStringCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.IReadableStringCollection.ContainsKey(System.String)
    
        
    
        Determines whether the collection contains an element with the specified key.
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ContainsKey(string key)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.IReadableStringCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.IReadableStringCollection.Count
    
        
    
        Gets the number of elements contained in the collection.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.IReadableStringCollection.Item[System.String]
    
        
    
        Get the associated value from the collection.
        Returns StringValues.Empty if the key is not present.
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           StringValues this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.IReadableStringCollection.Keys
    
        
    
        Gets a collection containing the keys.
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           ICollection<string> Keys { get; }
    


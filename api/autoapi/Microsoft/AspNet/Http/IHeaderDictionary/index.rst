

IHeaderDictionary Interface
===========================



.. contents:: 
   :local:



Summary
-------

Represents request and response headers











Syntax
------

.. code-block:: csharp

   public interface IHeaderDictionary : IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/IHeaderDictionary.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IHeaderDictionary

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.IHeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.IHeaderDictionary.Item[System.String]
    
        
    
        IHeaderDictionary has a different indexer contract than IDictionary, where it will return StringValues.Empty for missing entries.
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: The stored value, or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
           StringValues this[string key] { get; set; }
    


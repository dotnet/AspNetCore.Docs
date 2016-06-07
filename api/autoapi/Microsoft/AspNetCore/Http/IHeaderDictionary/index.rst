

IHeaderDictionary Interface
===========================






Represents HttpRequest and HttpResponse headers


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHeaderDictionary : IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Http.IHeaderDictionary
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IHeaderDictionary

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.IHeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.IHeaderDictionary.Item[System.String]
    
        
    
        
        IHeaderDictionary has a different indexer contract than IDictionary, where it will return StringValues.Empty for missing entries.
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: The stored value, or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
            StringValues this[string key]
            {
                get;
                set;
            }
    


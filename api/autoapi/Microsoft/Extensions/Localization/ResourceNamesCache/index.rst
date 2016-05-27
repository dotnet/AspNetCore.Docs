

ResourceNamesCache Class
========================






An implementation of :any:`Microsoft.Extensions.Localization.IResourceNamesCache` backed by a :any:`System.Collections.Concurrent.ConcurrentDictionary\`2`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.ResourceNamesCache`








Syntax
------

.. code-block:: csharp

    public class ResourceNamesCache : IResourceNamesCache








.. dn:class:: Microsoft.Extensions.Localization.ResourceNamesCache
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.ResourceNamesCache

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.ResourceNamesCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceNamesCache.GetOrAdd(System.String, System.Func<System.String, System.Collections.Generic.IList<System.String>>)
    
        
    
        
        :type name: System.String
    
        
        :type valueFactory: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> GetOrAdd(string name, Func<string, IList<string>> valueFactory)
    


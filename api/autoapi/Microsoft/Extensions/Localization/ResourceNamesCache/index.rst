

ResourceNamesCache Class
========================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.Extensions.Localization.IResourceNamesCache` backed by a :any:`System.Collections.Concurrent.ConcurrentDictionary\`2`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.ResourceNamesCache`








Syntax
------

.. code-block:: csharp

   public class ResourceNamesCache : IResourceNamesCache





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.Extensions.Localization/ResourceNamesCache.cs>`_





.. dn:class:: Microsoft.Extensions.Localization.ResourceNamesCache

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.ResourceNamesCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceNamesCache.GetOrAdd(System.String, System.Func<System.String, System.Collections.Generic.IList<System.String>>)
    
        
        
        
        :type name: System.String
        
        
        :type valueFactory: System.Func{System.String,System.Collections.Generic.IList{System.String}}
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> GetOrAdd(string name, Func<string, IList<string>> valueFactory)
    


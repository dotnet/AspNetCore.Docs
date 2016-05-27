

IResourceNamesCache Interface
=============================






Represents a cache of string names in resources.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IResourceNamesCache








.. dn:interface:: Microsoft.Extensions.Localization.IResourceNamesCache
    :hidden:

.. dn:interface:: Microsoft.Extensions.Localization.IResourceNamesCache

Methods
-------

.. dn:interface:: Microsoft.Extensions.Localization.IResourceNamesCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.IResourceNamesCache.GetOrAdd(System.String, System.Func<System.String, System.Collections.Generic.IList<System.String>>)
    
        
    
        
        Adds a set of resource names to the cache by using the specified function, if the name does not already exist.
    
        
    
        
        :param name: The resource name to add string names for.
        
        :type name: System.String
    
        
        :param valueFactory: The function used to generate the string names for the resource.
        
        :type valueFactory: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :return: The string names for the resource.
    
        
        .. code-block:: csharp
    
            IList<string> GetOrAdd(string name, Func<string, IList<string>> valueFactory)
    


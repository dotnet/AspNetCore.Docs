

IResourceNamesCache Interface
=============================



.. contents:: 
   :local:



Summary
-------

Represents a cache of string names in resources.











Syntax
------

.. code-block:: csharp

   public interface IResourceNamesCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization/IResourceNamesCache.cs>`_





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
        
        :type valueFactory: System.Func{System.String,System.Collections.Generic.IList{System.String}}
        :rtype: System.Collections.Generic.IList{System.String}
        :return: The string names for the resource.
    
        
        .. code-block:: csharp
    
           IList<string> GetOrAdd(string name, Func<string, IList<string>> valueFactory)
    


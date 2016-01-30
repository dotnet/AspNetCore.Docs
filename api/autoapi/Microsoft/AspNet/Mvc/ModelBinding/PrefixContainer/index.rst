

PrefixContainer Class
=====================



.. contents:: 
   :local:



Summary
-------

This is a container for prefix values. It normalizes all the values into dotted-form and then stores
them in a sorted array. All queries for prefixes are also normalized to dotted-form, and searches
for ContainsPrefix are done with a binary search.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer`








Syntax
------

.. code-block:: csharp

   public class PrefixContainer





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/PrefixContainer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer.PrefixContainer(System.Collections.Generic.ICollection<System.String>)
    
        
        
        
        :type values: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public PrefixContainer(ICollection<string> values)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer.ContainsPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer.GetKeysFromPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer.IsPrefixMatch(System.String, System.String)
    
        
        
        
        :type prefix: System.String
        
        
        :type testString: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsPrefixMatch(string prefix, string testString)
    


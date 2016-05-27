

PrefixContainer Class
=====================






This is a container for prefix values. It normalizes all the values into dotted-form and then stores
them in a sorted array. All queries for prefixes are also normalized to dotted-form, and searches
for ContainsPrefix are done with a binary search.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.PrefixContainer`








Syntax
------

.. code-block:: csharp

    public class PrefixContainer








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer.PrefixContainer(System.Collections.Generic.ICollection<System.String>)
    
        
    
        
        :type values: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public PrefixContainer(ICollection<string> values)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer.GetKeysFromPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> GetKeysFromPrefix(string prefix)
    


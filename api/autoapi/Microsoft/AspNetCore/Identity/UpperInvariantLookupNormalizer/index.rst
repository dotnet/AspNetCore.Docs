

UpperInvariantLookupNormalizer Class
====================================






Implements :any:`Microsoft.AspNetCore.Identity.ILookupNormalizer` by converting keys to their upper cased invariant culture representation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.UpperInvariantLookupNormalizer`








Syntax
------

.. code-block:: csharp

    public class UpperInvariantLookupNormalizer : ILookupNormalizer








.. dn:class:: Microsoft.AspNetCore.Identity.UpperInvariantLookupNormalizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.UpperInvariantLookupNormalizer

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.UpperInvariantLookupNormalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.UpperInvariantLookupNormalizer.Normalize(System.String)
    
        
    
        
        Returns a normalized representation of the specified <em>key</em>
        by converting keys to their upper cased invariant culture representation.
    
        
    
        
        :param key: The key to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized representation of the specified <em>key</em>.
    
        
        .. code-block:: csharp
    
            public virtual string Normalize(string key)
    


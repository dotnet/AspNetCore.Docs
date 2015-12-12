

UpperInvariantLookupNormalizer Class
====================================



.. contents:: 
   :local:



Summary
-------

Implements :any:`Microsoft.AspNet.Identity.ILookupNormalizer` by converting keys to their upper cased invariant culture representation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UpperInvariantLookupNormalizer`








Syntax
------

.. code-block:: csharp

   public class UpperInvariantLookupNormalizer : ILookupNormalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/UpperInvariantLookupNormalizer.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.UpperInvariantLookupNormalizer

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.UpperInvariantLookupNormalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.UpperInvariantLookupNormalizer.Normalize(System.String)
    
        
    
        Returns a normalized representation of the specified ``key``
        by converting keys to their upper cased invariant culture representation.
    
        
        
        
        :param key: The key to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized representation of the specified <paramref name="key" />.
    
        
        .. code-block:: csharp
    
           public virtual string Normalize(string key)
    


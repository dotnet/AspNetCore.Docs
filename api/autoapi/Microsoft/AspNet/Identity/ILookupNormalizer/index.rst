

ILookupNormalizer Interface
===========================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for normalizing keys for lookup purposes.











Syntax
------

.. code-block:: csharp

   public interface ILookupNormalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/ILookupNormalizer.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.ILookupNormalizer

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.ILookupNormalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.ILookupNormalizer.Normalize(System.String)
    
        
    
        Returns a normalized representation of the specified ``key``.
    
        
        
        
        :param key: The key to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized representation of the specified <paramref name="key" />.
    
        
        .. code-block:: csharp
    
           string Normalize(string key)
    


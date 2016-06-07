

ILookupNormalizer Interface
===========================






Provides an abstraction for normalizing keys for lookup purposes.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ILookupNormalizer








.. dn:interface:: Microsoft.AspNetCore.Identity.ILookupNormalizer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.ILookupNormalizer

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.ILookupNormalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.ILookupNormalizer.Normalize(System.String)
    
        
    
        
        Returns a normalized representation of the specified <em>key</em>.
    
        
    
        
        :param key: The key to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized representation of the specified <em>key</em>.
    
        
        .. code-block:: csharp
    
            string Normalize(string key)
    




ICacheableKeyRingProvider Interface
===================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement.Internal`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICacheableKeyRingProvider








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.ICacheableKeyRingProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.ICacheableKeyRingProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.ICacheableKeyRingProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.ICacheableKeyRingProvider.GetCacheableKeyRing(System.DateTimeOffset)
    
        
    
        
        :type now: System.DateTimeOffset
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.CacheableKeyRing
    
        
        .. code-block:: csharp
    
            CacheableKeyRing GetCacheableKeyRing(DateTimeOffset now)
    


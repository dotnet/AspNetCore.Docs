

IDefaultKeyResolver Interface
=============================






Implements policy for resolving the default key from a candidate keyring.


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

    public interface IDefaultKeyResolver








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyResolver
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyResolver

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyResolver.ResolveDefaultKeyPolicy(System.DateTimeOffset, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.DataProtection.KeyManagement.IKey>)
    
        
    
        
        Locates the default key from the keyring.
    
        
    
        
        :type now: System.DateTimeOffset
    
        
        :type allKeys: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.DataProtection.KeyManagement.IKey<Microsoft.AspNetCore.DataProtection.KeyManagement.IKey>}
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution
    
        
        .. code-block:: csharp
    
            DefaultKeyResolution ResolveDefaultKeyPolicy(DateTimeOffset now, IEnumerable<IKey> allKeys)
    


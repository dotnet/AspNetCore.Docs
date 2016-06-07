

DefaultKeyResolution Struct
===========================





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

    public struct DefaultKeyResolution








.. dn:structure:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution

Fields
------

.. dn:structure:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution.DefaultKey
    
        
    
        
        The default key, may be null if no key is a good default candidate.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    
        
        .. code-block:: csharp
    
            public IKey DefaultKey
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution.FallbackKey
    
        
    
        
        The fallback key, which should be used only if the caller is configured not to
        honor the :dn:field:`Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution.ShouldGenerateNewKey` property. This property may
        be null if there is no viable fallback key.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    
        
        .. code-block:: csharp
    
            public IKey FallbackKey
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution.ShouldGenerateNewKey
    
        
    
        
        'true' if a new key should be persisted to the keyring, 'false' otherwise.
        This value may be 'true' even if a valid default key was found.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ShouldGenerateNewKey
    


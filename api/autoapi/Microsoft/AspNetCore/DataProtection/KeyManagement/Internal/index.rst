

Microsoft.AspNetCore.DataProtection.KeyManagement.Internal Namespace
====================================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/CacheableKeyRing/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/DefaultKeyResolution/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/ICacheableKeyRingProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/IDefaultKeyResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/IDefaultKeyServices/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/IInternalXmlKeyManager/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/IKeyRing/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/Internal/IKeyRingProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal


    .. rubric:: Interfaces


    interface :dn:iface:`ICacheableKeyRingProvider`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.ICacheableKeyRingProvider

        


    interface :dn:iface:`IDefaultKeyResolver`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyResolver

        
        Implements policy for resolving the default key from a candidate keyring.


    interface :dn:iface:`IDefaultKeyServices`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyServices

        
        Provides default implementations of the services required by an :any:`Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyManager`\.


    interface :dn:iface:`IInternalXmlKeyManager`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager

        


    interface :dn:iface:`IKeyRing`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing

        
        The basic interface for accessing a read-only keyring.


    interface :dn:iface:`IKeyRingProvider`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRingProvider

        


    .. rubric:: Classes


    class :dn:cls:`CacheableKeyRing`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.CacheableKeyRing

        
        Wraps both a keyring and its expiration policy.


    .. rubric:: Structures


    struct :dn:struct:`DefaultKeyResolution`
        .. object: type=struct name=Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution

        



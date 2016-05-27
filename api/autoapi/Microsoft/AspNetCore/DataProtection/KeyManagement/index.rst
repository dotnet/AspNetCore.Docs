

Microsoft.AspNetCore.DataProtection.KeyManagement Namespace
===========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/IKey/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/IKeyEscrowSink/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/IKeyManager/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/KeyManagementOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/KeyManagement/XmlKeyManager/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.DataProtection.KeyManagement


    .. rubric:: Classes


    class :dn:cls:`KeyManagementOptions`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions

        
        Options that control how an :any:`Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyManager` should behave.


    class :dn:cls:`XmlKeyManager`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager

        
        A key manager backed by an :any:`Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository`\.


    .. rubric:: Interfaces


    interface :dn:iface:`IKey`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.IKey

        
        The basic interface for representing an authenticated encryption key.


    interface :dn:iface:`IKeyEscrowSink`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyEscrowSink

        
        The basic interface for implementing a key escrow sink.


    interface :dn:iface:`IKeyManager`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyManager

        
        The basic interface for performing key management operations.





Microsoft.AspNetCore.DataProtection Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/DataProtectionBuilderExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/DataProtectionExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/DataProtectionOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/DataProtectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/EphemeralDataProtectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/IDataProtectionBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/IDataProtectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/IDataProtector/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/IPersistedDataProtector/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/ISecret/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/ITimeLimitedDataProtector/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/Secret/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.DataProtection


    .. rubric:: Classes


    class :dn:cls:`DataProtectionBuilderExtensions`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions

        
        Extensions for configuring data protection using an :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder`\.


    class :dn:cls:`DataProtectionExtensions`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.DataProtectionExtensions

        
        Helpful extension methods for data protection APIs.


    class :dn:cls:`DataProtectionOptions`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.DataProtectionOptions

        
        Provides global options for the Data Protection system.


    class :dn:cls:`DataProtectionProvider`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.DataProtectionProvider

        
        Contains factory methods for creating an :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` where keys are stored
        at a particular location on the file system.


    class :dn:cls:`EphemeralDataProtectionProvider`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider

        
        An :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` that is transient.


    class :dn:cls:`Secret`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.Secret

        
        Represents a secret value stored in memory.


    .. rubric:: Interfaces


    interface :dn:iface:`IDataProtectionBuilder`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder

        
        Provides access to configuration for the data protection system, which allows the
        developer to configure default cryptographic algorithms, key storage locations,
        and the mechanism by which keys are protected at rest.


    interface :dn:iface:`IDataProtectionProvider`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.IDataProtectionProvider

        
        An interface that can be used to create :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` instances.


    interface :dn:iface:`IDataProtector`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.IDataProtector

        
        An interface that can provide data protection services.


    interface :dn:iface:`IPersistedDataProtector`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.IPersistedDataProtector

        
        An interface that can provide data protection services for data which has been persisted
        to long-term storage.


    interface :dn:iface:`ISecret`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.ISecret

        
        Represents a secret value.


    interface :dn:iface:`ITimeLimitedDataProtector`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector

        
        An interface that can provide data protection services where payloads have
        a finite lifetime.



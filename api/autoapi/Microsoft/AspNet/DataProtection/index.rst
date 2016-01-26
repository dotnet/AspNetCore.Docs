

Microsoft.AspNet.DataProtection Namespace
=========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/DataProtection/DataProtectionConfiguration/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/DataProtectionExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/DataProtectionOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/DataProtectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/EphemeralDataProtectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/IDataProtectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/IDataProtector/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/IPersistedDataProtector/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/ISecret/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/ITimeLimitedDataProtector/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/Secret/index
   
   











.. dn:namespace:: Microsoft.AspNet.DataProtection


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionConfiguration`
        Provides access to configuration for the data protection system, which allows the
        developer to configure default cryptographic algorithms, key storage locations,
        and the mechanism by which keys are protected at rest.


    class :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionExtensions`
        Helpful extension methods for data protection APIs.


    class :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionOptions`
        Provides global options for the Data Protection system.


    class :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionProvider`
        A simple implementation of an :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider` where keys are stored
        at a particular location on the file system.


    class :dn:cls:`Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider`
        An :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider` that is transient.


    class :dn:cls:`Microsoft.AspNet.DataProtection.Secret`
        Represents a secret value stored in memory.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.DataProtection.IDataProtectionProvider`
        An interface that can be used to create :any:`Microsoft.AspNet.DataProtection.IDataProtector` instances.


    interface :dn:iface:`Microsoft.AspNet.DataProtection.IDataProtector`
        An interface that can provide data protection services.


    interface :dn:iface:`Microsoft.AspNet.DataProtection.IPersistedDataProtector`
        An interface that can provide data protection services for data which has been persisted
        to long-term storage.


    interface :dn:iface:`Microsoft.AspNet.DataProtection.ISecret`
        Represents a secret value.


    interface :dn:iface:`Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector`
        An interface that can provide data protection services where payloads have
        a finite lifetime.



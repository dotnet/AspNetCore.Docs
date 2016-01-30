

DpapiNGProtectionDescriptorFlags Enum
=====================================



.. contents:: 
   :local:



Summary
-------

Flags used to control the creation of protection descriptors.











Syntax
------

.. code-block:: csharp

   public enum DpapiNGProtectionDescriptorFlags





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/DpapiNGProtectionDescriptorFlags.cs>`_





.. dn:enumeration:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags

Fields
------

.. dn:enumeration:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.MachineKey
    
        
    
        When combined with :dn:field:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.NamedDescriptor`\, uses the HKLM registry
        instead of the HKCU registry when locating the full descriptor.
    
        
    
        
        .. code-block:: csharp
    
           MachineKey = 32
    
    .. dn:field:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.NamedDescriptor
    
        
    
        The provided descriptor is a reference to a full descriptor stored
        in the system registry.
    
        
    
        
        .. code-block:: csharp
    
           NamedDescriptor = 1
    
    .. dn:field:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.None
    
        
    
        No special handling is necessary.
    
        
    
        
        .. code-block:: csharp
    
           None = 0
    


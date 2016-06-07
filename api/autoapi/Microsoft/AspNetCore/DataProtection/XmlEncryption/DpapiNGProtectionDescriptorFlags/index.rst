

DpapiNGProtectionDescriptorFlags Enum
=====================================






Flags used to control the creation of protection descriptors.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.XmlEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [Flags]
    public enum DpapiNGProtectionDescriptorFlags








.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.MachineKey
    
        
    
        
        When combined with :dn:field:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.NamedDescriptor`\, uses the HKLM registry
        instead of the HKCU registry when locating the full descriptor.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    
        
        .. code-block:: csharp
    
            MachineKey = 32
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.NamedDescriptor
    
        
    
        
        The provided descriptor is a reference to a full descriptor stored
        in the system registry.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    
        
        .. code-block:: csharp
    
            NamedDescriptor = 1
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags.None
    
        
    
        
        No special handling is necessary.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    
        
        .. code-block:: csharp
    
            None = 0
    


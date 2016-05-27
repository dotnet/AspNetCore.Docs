

Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel Namespace
========================================================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/AuthenticatedEncryptorConfiguration/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/AuthenticatedEncryptorDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/AuthenticatedEncryptorDescriptorDeserializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/CngCbcAuthenticatedEncryptorConfiguration/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/CngCbcAuthenticatedEncryptorDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/CngCbcAuthenticatedEncryptorDescriptorDeserializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/CngGcmAuthenticatedEncryptorConfiguration/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/CngGcmAuthenticatedEncryptorDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/CngGcmAuthenticatedEncryptorDescriptorDeserializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/IAuthenticatedEncryptorConfiguration/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/IAuthenticatedEncryptorDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/IAuthenticatedEncryptorDescriptorDeserializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/ManagedAuthenticatedEncryptorConfiguration/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/ManagedAuthenticatedEncryptorDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/ManagedAuthenticatedEncryptorDescriptorDeserializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/XmlExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ConfigurationModel/XmlSerializedDescriptorInfo/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel


    .. rubric:: Classes


    class :dn:cls:`AuthenticatedEncryptorConfiguration`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration

        
        Represents a generalized authenticated encryption mechanism.


    class :dn:cls:`AuthenticatedEncryptorDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor

        
        A descriptor which can create an authenticated encryption system based upon the
        configuration provided by an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings` object.


    class :dn:cls:`AuthenticatedEncryptorDescriptorDeserializer`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer

        
        A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
        of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor`\.


    class :dn:cls:`CngCbcAuthenticatedEncryptorConfiguration`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorConfiguration

        
        Represents a configured authenticated encryption mechanism which uses
        Windows CNG algorithms in CBC encryption + HMAC authentication modes.


    class :dn:cls:`CngCbcAuthenticatedEncryptorDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor

        
        A descriptor which can create an authenticated encryption system based upon the
        configuration provided by an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings` object.


    class :dn:cls:`CngCbcAuthenticatedEncryptorDescriptorDeserializer`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer

        
        A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
        of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor`\.


    class :dn:cls:`CngGcmAuthenticatedEncryptorConfiguration`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration

        
        Represents a configured authenticated encryption mechanism which uses
        Windows CNG algorithms in GCM encryption + authentication modes.


    class :dn:cls:`CngGcmAuthenticatedEncryptorDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor

        
        A descriptor which can create an authenticated encryption system based upon the
        configuration provided by an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings` object.


    class :dn:cls:`CngGcmAuthenticatedEncryptorDescriptorDeserializer`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptorDeserializer

        
        A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
        of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor`\.


    class :dn:cls:`ManagedAuthenticatedEncryptorConfiguration`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration

        
        Represents a configured authenticated encryption mechanism which uses
        managed :any:`System.Security.Cryptography.SymmetricAlgorithm` and
        :any:`System.Security.Cryptography.KeyedHashAlgorithm` types.


    class :dn:cls:`ManagedAuthenticatedEncryptorDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor

        
        A descriptor which can create an authenticated encryption system based upon the
        configuration provided by an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings` object.


    class :dn:cls:`ManagedAuthenticatedEncryptorDescriptorDeserializer`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer

        
        A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
        of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor`\.


    class :dn:cls:`XmlExtensions`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions

        


    class :dn:cls:`XmlSerializedDescriptorInfo`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo

        
        Wraps an :any:`System.Xml.Linq.XElement` that contains the XML-serialized representation of an
        :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor` along with the type that can be used
        to deserialize it.


    .. rubric:: Interfaces


    interface :dn:iface:`IAuthenticatedEncryptorConfiguration`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration

        
        The basic configuration that serves as a factory for types related to authenticated encryption.


    interface :dn:iface:`IAuthenticatedEncryptorDescriptor`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor

        
        A self-contained descriptor that wraps all information (including secret key
        material) necessary to create an instance of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor`\.


    interface :dn:iface:`IAuthenticatedEncryptorDescriptorDeserializer`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer

        
        The basic interface for deserializing an XML element into an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.



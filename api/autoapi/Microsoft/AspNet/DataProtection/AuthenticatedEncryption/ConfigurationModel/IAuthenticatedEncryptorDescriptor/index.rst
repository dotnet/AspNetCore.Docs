

IAuthenticatedEncryptorDescriptor Interface
===========================================



.. contents:: 
   :local:



Summary
-------

A self-contained descriptor that wraps all information (including secret key
material) necessary to create an instance of an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor`\.











Syntax
------

.. code-block:: csharp

   public interface IAuthenticatedEncryptorDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/IAuthenticatedEncryptorDescriptor.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor` instance based on the current descriptor.
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor" /> instance.
    
        
        .. code-block:: csharp
    
           IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor.ExportToXml()
    
        
    
        Exports the current descriptor to XML.
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo" /> wrapping the <see cref="T:System.Xml.Linq.XElement" /> which represents the serialized
            current descriptor object. The deserializer type must be assignable to <see cref="T:Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer" />.
    
        
        .. code-block:: csharp
    
           XmlSerializedDescriptorInfo ExportToXml()
    


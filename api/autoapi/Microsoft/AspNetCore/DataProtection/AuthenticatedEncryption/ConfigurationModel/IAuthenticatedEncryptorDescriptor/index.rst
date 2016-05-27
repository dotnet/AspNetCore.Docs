

IAuthenticatedEncryptorDescriptor Interface
===========================================






A self-contained descriptor that wraps all information (including secret key
material) necessary to create an instance of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthenticatedEncryptorDescriptor








.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor` instance based on the current descriptor.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
        :return: An :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor` instance.
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor.ExportToXml()
    
        
    
        
        Exports the current descriptor to XML.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
        :return: 
            An :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo` wrapping the :any:`System.Xml.Linq.XElement` which represents the serialized
            current descriptor object. The deserializer type must be assignable to :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer`\.
    
        
        .. code-block:: csharp
    
            XmlSerializedDescriptorInfo ExportToXml()
    


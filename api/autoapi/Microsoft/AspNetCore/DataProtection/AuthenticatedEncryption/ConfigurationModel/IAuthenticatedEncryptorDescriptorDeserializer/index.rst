

IAuthenticatedEncryptorDescriptorDeserializer Interface
=======================================================






The basic interface for deserializing an XML element into an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.


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

    public interface IAuthenticatedEncryptorDescriptorDeserializer








.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)
    
        
    
        
        Deserializes the specified XML element.
    
        
    
        
        :param element: The element to deserialize.
        
        :type element: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
        :return: The :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor` represented by <em>element</em>.
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptorDescriptor ImportFromXml(XElement element)
    


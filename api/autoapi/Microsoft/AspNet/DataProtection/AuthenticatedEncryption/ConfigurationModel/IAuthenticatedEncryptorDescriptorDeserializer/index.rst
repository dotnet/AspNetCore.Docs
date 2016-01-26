

IAuthenticatedEncryptorDescriptorDeserializer Interface
=======================================================



.. contents:: 
   :local:



Summary
-------

The basic interface for deserializing an XML element into an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.











Syntax
------

.. code-block:: csharp

   public interface IAuthenticatedEncryptorDescriptorDeserializer





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/IAuthenticatedEncryptorDescriptorDeserializer.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)
    
        
    
        Deserializes the specified XML element.
    
        
        
        
        :param element: The element to deserialize.
        
        :type element: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
        :return: The <see cref="T:Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor" /> represented by <paramref name="element" />.
    
        
        .. code-block:: csharp
    
           IAuthenticatedEncryptorDescriptor ImportFromXml(XElement element)
    




AuthenticatedEncryptorDescriptorDeserializer Class
==================================================



.. contents:: 
   :local:



Summary
-------

A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
of an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer`








Syntax
------

.. code-block:: csharp

   public sealed class AuthenticatedEncryptorDescriptorDeserializer : IAuthenticatedEncryptorDescriptorDeserializer





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/AuthenticatedEncryptorDescriptorDeserializer.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer.AuthenticatedEncryptorDescriptorDeserializer()
    
        
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptorDescriptorDeserializer()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer.AuthenticatedEncryptorDescriptorDeserializer(System.IServiceProvider)
    
        
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptorDescriptorDeserializer(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)
    
        
    
        Imports the :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor` from serialized XML.
    
        
        
        
        :type element: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptorDescriptor ImportFromXml(XElement element)
    


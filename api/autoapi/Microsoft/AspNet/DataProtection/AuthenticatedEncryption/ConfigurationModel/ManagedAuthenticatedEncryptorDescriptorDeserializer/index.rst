

ManagedAuthenticatedEncryptorDescriptorDeserializer Class
=========================================================



.. contents:: 
   :local:



Summary
-------

A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
of an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer`








Syntax
------

.. code-block:: csharp

   public sealed class ManagedAuthenticatedEncryptorDescriptorDeserializer : IAuthenticatedEncryptorDescriptorDeserializer





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/ManagedAuthenticatedEncryptorDescriptorDeserializer.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer.ManagedAuthenticatedEncryptorDescriptorDeserializer()
    
        
    
        
        .. code-block:: csharp
    
           public ManagedAuthenticatedEncryptorDescriptorDeserializer()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer.ManagedAuthenticatedEncryptorDescriptorDeserializer(System.IServiceProvider)
    
        
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public ManagedAuthenticatedEncryptorDescriptorDeserializer(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)
    
        
    
        Imports the :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor` from serialized XML.
    
        
        
        
        :type element: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptorDescriptor ImportFromXml(XElement element)
    


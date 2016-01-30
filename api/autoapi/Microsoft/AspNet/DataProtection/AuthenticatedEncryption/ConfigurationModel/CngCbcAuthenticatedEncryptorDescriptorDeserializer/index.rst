

CngCbcAuthenticatedEncryptorDescriptorDeserializer Class
========================================================



.. contents:: 
   :local:



Summary
-------

A class that can deserialize an :any:`System.Xml.Linq.XElement` that represents the serialized version
of an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer`








Syntax
------

.. code-block:: csharp

   public sealed class CngCbcAuthenticatedEncryptorDescriptorDeserializer : IAuthenticatedEncryptorDescriptorDeserializer





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/CngCbcAuthenticatedEncryptorDescriptorDeserializer.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer.CngCbcAuthenticatedEncryptorDescriptorDeserializer()
    
        
    
        
        .. code-block:: csharp
    
           public CngCbcAuthenticatedEncryptorDescriptorDeserializer()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer.CngCbcAuthenticatedEncryptorDescriptorDeserializer(System.IServiceProvider)
    
        
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public CngCbcAuthenticatedEncryptorDescriptorDeserializer(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)
    
        
    
        Imports the :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor` from serialized XML.
    
        
        
        
        :type element: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptorDescriptor ImportFromXml(XElement element)
    


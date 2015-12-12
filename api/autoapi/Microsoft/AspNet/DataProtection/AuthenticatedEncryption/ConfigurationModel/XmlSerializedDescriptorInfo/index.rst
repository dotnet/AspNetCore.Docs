

XmlSerializedDescriptorInfo Class
=================================



.. contents:: 
   :local:



Summary
-------

Wraps an :any:`System.Xml.Linq.XElement` that contains the XML-serialized representation of an 
:any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor` along with the type that can be used
to deserialize it.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo`








Syntax
------

.. code-block:: csharp

   public sealed class XmlSerializedDescriptorInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/XmlSerializedDescriptorInfo.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.XmlSerializedDescriptorInfo(System.Xml.Linq.XElement, System.Type)
    
        
    
        Creates an instance of an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo`\.
    
        
        
        
        :param serializedDescriptorElement: The XML-serialized form of the .
        
        :type serializedDescriptorElement: System.Xml.Linq.XElement
        
        
        :param deserializerType: The class whose
            method can be used to deserialize .
        
        :type deserializerType: System.Type
    
        
        .. code-block:: csharp
    
           public XmlSerializedDescriptorInfo(XElement serializedDescriptorElement, Type deserializerType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.DeserializerType
    
        
    
        The class whose :dn:meth:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)`
        method can be used to deserialize the value stored in :dn:prop:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.SerializedDescriptorElement`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type DeserializerType { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.SerializedDescriptorElement
    
        
    
        An XML-serialized representation of an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.
    
        
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           public XElement SerializedDescriptorElement { get; }
    


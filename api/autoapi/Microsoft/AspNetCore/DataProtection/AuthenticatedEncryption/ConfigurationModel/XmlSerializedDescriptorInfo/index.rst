

XmlSerializedDescriptorInfo Class
=================================






Wraps an :any:`System.Xml.Linq.XElement` that contains the XML-serialized representation of an 
:any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor` along with the type that can be used
to deserialize it.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo`








Syntax
------

.. code-block:: csharp

    public sealed class XmlSerializedDescriptorInfo








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.XmlSerializedDescriptorInfo(System.Xml.Linq.XElement, System.Type)
    
        
    
        
        Creates an instance of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo`\.
    
        
    
        
        :param serializedDescriptorElement: The XML-serialized form of the :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.
        
        :type serializedDescriptorElement: System.Xml.Linq.XElement
    
        
        :param deserializerType: The class whose :dn:meth:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)`
            method can be used to deserialize <em>serializedDescriptorElement</em>.
        
        :type deserializerType: System.Type
    
        
        .. code-block:: csharp
    
            public XmlSerializedDescriptorInfo(XElement serializedDescriptorElement, Type deserializerType)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.DeserializerType
    
        
    
        
        The class whose :dn:meth:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptorDeserializer.ImportFromXml(System.Xml.Linq.XElement)`
        method can be used to deserialize the value stored in :dn:prop:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.SerializedDescriptorElement`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type DeserializerType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo.SerializedDescriptorElement
    
        
    
        
        An XML-serialized representation of an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.
    
        
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
            public XElement SerializedDescriptorElement { get; }
    


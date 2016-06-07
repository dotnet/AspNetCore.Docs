

EncryptedXmlInfo Class
======================






Wraps an :any:`System.Xml.Linq.XElement` that contains a blob of encrypted XML
and information about the class which can be used to decrypt it.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.XmlEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo`








Syntax
------

.. code-block:: csharp

    public sealed class EncryptedXmlInfo








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo.DecryptorType
    
        
    
        
        The class whose :dn:meth:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor.Decrypt(System.Xml.Linq.XElement)` method can be used to
        decrypt the value stored in :dn:prop:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo.EncryptedElement`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type DecryptorType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo.EncryptedElement
    
        
    
        
        A piece of encrypted XML.
    
        
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
            public XElement EncryptedElement
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo.EncryptedXmlInfo(System.Xml.Linq.XElement, System.Type)
    
        
    
        
        Creates an instance of an :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo`\.
    
        
    
        
        :param encryptedElement: A piece of encrypted XML.
        
        :type encryptedElement: System.Xml.Linq.XElement
    
        
        :param decryptorType: The class whose :dn:meth:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor.Decrypt(System.Xml.Linq.XElement)`
            method can be used to decrypt <em>encryptedElement</em>.
        
        :type decryptorType: System.Type
    
        
        .. code-block:: csharp
    
            public EncryptedXmlInfo(XElement encryptedElement, Type decryptorType)
    


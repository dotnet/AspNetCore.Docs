

EncryptedXmlInfo Class
======================



.. contents:: 
   :local:



Summary
-------

Wraps an :any:`System.Xml.Linq.XElement` that contains a blob of encrypted XML
and information about the class which can be used to decrypt it.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo`








Syntax
------

.. code-block:: csharp

   public sealed class EncryptedXmlInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/XmlEncryption/EncryptedXmlInfo.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo.EncryptedXmlInfo(System.Xml.Linq.XElement, System.Type)
    
        
    
        Creates an instance of an :any:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo`\.
    
        
        
        
        :param encryptedElement: A piece of encrypted XML.
        
        :type encryptedElement: System.Xml.Linq.XElement
        
        
        :param decryptorType: The class whose
            method can be used to decrypt .
        
        :type decryptorType: System.Type
    
        
        .. code-block:: csharp
    
           public EncryptedXmlInfo(XElement encryptedElement, Type decryptorType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo.DecryptorType
    
        
    
        The class whose :dn:meth:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor.Decrypt(System.Xml.Linq.XElement)` method can be used to
        decrypt the value stored in :dn:prop:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo.EncryptedElement`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type DecryptorType { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo.EncryptedElement
    
        
    
        A piece of encrypted XML.
    
        
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           public XElement EncryptedElement { get; }
    


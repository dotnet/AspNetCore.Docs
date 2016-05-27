

EncryptedXmlDecryptor Class
===========================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements by using the :any:`System.Security.Cryptography.Xml.EncryptedXml` class.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor`








Syntax
------

.. code-block:: csharp

    public sealed class EncryptedXmlDecryptor : IInternalEncryptedXmlDecryptor, IXmlDecryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor.EncryptedXmlDecryptor()
    
        
    
        
        Creates a new instance of an :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor`\.
    
        
    
        
        .. code-block:: csharp
    
            public EncryptedXmlDecryptor()
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor.EncryptedXmlDecryptor(System.IServiceProvider)
    
        
    
        
        Creates a new instance of an :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor`\.
    
        
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public EncryptedXmlDecryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
    
        
        Decrypts the specified XML element.
    
        
    
        
        :param encryptedElement: An encrypted XML element.
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
        :return: The decrypted form of <em>encryptedElement</em>.
    
        
        .. code-block:: csharp
    
            public XElement Decrypt(XElement encryptedElement)
    


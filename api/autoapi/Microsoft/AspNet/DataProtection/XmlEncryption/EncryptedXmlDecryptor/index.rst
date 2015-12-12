

EncryptedXmlDecryptor Class
===========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements by using the :any:`System.Security.Cryptography.Xml.EncryptedXml` class.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor`








Syntax
------

.. code-block:: csharp

   public sealed class EncryptedXmlDecryptor : IInternalEncryptedXmlDecryptor, IXmlDecryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/XmlEncryption/EncryptedXmlDecryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor.EncryptedXmlDecryptor()
    
        
    
        Creates a new instance of an :any:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor`\.
    
        
    
        
        .. code-block:: csharp
    
           public EncryptedXmlDecryptor()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor.EncryptedXmlDecryptor(System.IServiceProvider)
    
        
    
        Creates a new instance of an :any:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor`\.
    
        
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public EncryptedXmlDecryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
        
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           public XElement Decrypt(XElement encryptedElement)
    


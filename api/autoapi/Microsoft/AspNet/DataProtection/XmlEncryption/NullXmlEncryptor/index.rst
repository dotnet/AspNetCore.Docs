

NullXmlEncryptor Class
======================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML elements with a null encryptor.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor`








Syntax
------

.. code-block:: csharp

   public sealed class NullXmlEncryptor : IXmlEncryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/NullXmlEncryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor.NullXmlEncryptor()
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor`\.
    
        
    
        
        .. code-block:: csharp
    
           public NullXmlEncryptor()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor.NullXmlEncryptor(System.IServiceProvider)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor`\.
    
        
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public NullXmlEncryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        Encrypts the specified :any:`System.Xml.Linq.XElement` with a null encryptor, i.e.,
        by returning the original value of ``plaintextElement`` unencrypted.
    
        
        
        
        :param plaintextElement: The plaintext to echo back.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo" /> that contains the null-encrypted value of
            <paramref name="plaintextElement" /> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
           public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


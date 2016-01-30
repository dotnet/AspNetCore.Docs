

IXmlEncryptor Interface
=======================



.. contents:: 
   :local:



Summary
-------

The basic interface for encrypting XML elements.











Syntax
------

.. code-block:: csharp

   public interface IXmlEncryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/IXmlEncryptor.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        Encrypts the specified :any:`System.Xml.Linq.XElement`\.
    
        
        
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo" /> that contains the encrypted value of
            <paramref name="plaintextElement" /> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
           EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


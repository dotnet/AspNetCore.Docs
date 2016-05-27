

IXmlEncryptor Interface
=======================






The basic interface for encrypting XML elements.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.XmlEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IXmlEncryptor








.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        
        Encrypts the specified :any:`System.Xml.Linq.XElement`\.
    
        
    
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: 
            An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo` that contains the encrypted value of
            <em>plaintextElement</em> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
            EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


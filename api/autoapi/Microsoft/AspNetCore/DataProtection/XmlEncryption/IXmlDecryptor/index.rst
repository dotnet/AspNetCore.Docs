

IXmlDecryptor Interface
=======================






The basic interface for decrypting an XML element.


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

    public interface IXmlDecryptor








.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
    
        
        Decrypts the specified XML element.
    
        
    
        
        :param encryptedElement: An encrypted XML element.
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
        :return: The decrypted form of <em>encryptedElement</em>.
    
        
        .. code-block:: csharp
    
            XElement Decrypt(XElement encryptedElement)
    


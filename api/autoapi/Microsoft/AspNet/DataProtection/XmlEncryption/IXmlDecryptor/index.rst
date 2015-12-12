

IXmlDecryptor Interface
=======================



.. contents:: 
   :local:



Summary
-------

The basic interface for decrypting an XML element.











Syntax
------

.. code-block:: csharp

   public interface IXmlDecryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/XmlEncryption/IXmlDecryptor.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
    
        Decrypts the specified XML element.
    
        
        
        
        :param encryptedElement: An encrypted XML element.
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
        :return: The decrypted form of <paramref name="encryptedElement" />.
    
        
        .. code-block:: csharp
    
           XElement Decrypt(XElement encryptedElement)
    


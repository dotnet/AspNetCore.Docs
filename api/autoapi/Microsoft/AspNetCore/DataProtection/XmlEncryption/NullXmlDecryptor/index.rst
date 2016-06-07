

NullXmlDecryptor Class
======================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements with a null decryptor.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlDecryptor`








Syntax
------

.. code-block:: csharp

    public sealed class NullXmlDecryptor : IXmlDecryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlDecryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlDecryptor

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
    
        
        Decrypts the specified XML element.
    
        
    
        
        :param encryptedElement: An encrypted XML element.
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
        :return: The decrypted form of <em>encryptedElement</em>.
    
        
        .. code-block:: csharp
    
            public XElement Decrypt(XElement encryptedElement)
    


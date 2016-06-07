

DpapiXmlDecryptor Class
=======================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor`\.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor`








Syntax
------

.. code-block:: csharp

    public sealed class DpapiXmlDecryptor : IXmlDecryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor.DpapiXmlDecryptor()
    
        
    
        
        Creates a new instance of a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor`\.
    
        
    
        
        .. code-block:: csharp
    
            public DpapiXmlDecryptor()
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor.DpapiXmlDecryptor(System.IServiceProvider)
    
        
    
        
        Creates a new instance of a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor`\.
    
        
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public DpapiXmlDecryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
    
        
        Decrypts the specified XML element.
    
        
    
        
        :param encryptedElement: An encrypted XML element.
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
        :return: The decrypted form of <em>encryptedElement</em>.
    
        
        .. code-block:: csharp
    
            public XElement Decrypt(XElement encryptedElement)
    


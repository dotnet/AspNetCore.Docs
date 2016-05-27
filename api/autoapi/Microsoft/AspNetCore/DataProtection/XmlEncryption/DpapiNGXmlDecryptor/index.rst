

DpapiNGXmlDecryptor Class
=========================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`








Syntax
------

.. code-block:: csharp

    public sealed class DpapiNGXmlDecryptor : IXmlDecryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor.DpapiNGXmlDecryptor()
    
        
    
        
        Creates a new instance of a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`\.
    
        
    
        
        .. code-block:: csharp
    
            public DpapiNGXmlDecryptor()
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor.DpapiNGXmlDecryptor(System.IServiceProvider)
    
        
    
        
        Creates a new instance of a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`\.
    
        
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public DpapiNGXmlDecryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
    
        
        Decrypts the specified XML element.
    
        
    
        
        :param encryptedElement: An encrypted XML element.
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
        :return: The decrypted form of <em>encryptedElement</em>.
    
        
        .. code-block:: csharp
    
            public XElement Decrypt(XElement encryptedElement)
    


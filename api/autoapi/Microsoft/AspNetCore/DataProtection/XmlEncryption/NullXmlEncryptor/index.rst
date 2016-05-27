

NullXmlEncryptor Class
======================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML elements with a null encryptor.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor`








Syntax
------

.. code-block:: csharp

    public sealed class NullXmlEncryptor : IXmlEncryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor.NullXmlEncryptor()
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor`\.
    
        
    
        
        .. code-block:: csharp
    
            public NullXmlEncryptor()
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor.NullXmlEncryptor(System.IServiceProvider)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor`\.
    
        
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public NullXmlEncryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        
        Encrypts the specified :any:`System.Xml.Linq.XElement` with a null encryptor, i.e.,
        by returning the original value of <em>plaintextElement</em> unencrypted.
    
        
    
        
        :param plaintextElement: The plaintext to echo back.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: 
            An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo` that contains the null-encrypted value of
            <em>plaintextElement</em> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
            public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


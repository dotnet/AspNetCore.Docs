

DpapiNGXmlEncryptor Class
=========================






A class that can encrypt XML elements using Windows DPAPI:NG.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`








Syntax
------

.. code-block:: csharp

    public sealed class DpapiNGXmlEncryptor : IXmlEncryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor.DpapiNGXmlEncryptor(System.String, Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags)
    
        
    
        
        Creates a new instance of a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.
    
        
    
        
        :param protectionDescriptorRule: The rule string from which to create the protection descriptor.
        
        :type protectionDescriptorRule: System.String
    
        
        :param flags: Flags controlling the creation of the protection descriptor.
        
        :type flags: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    
        
        .. code-block:: csharp
    
            public DpapiNGXmlEncryptor(string protectionDescriptorRule, DpapiNGProtectionDescriptorFlags flags)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor.DpapiNGXmlEncryptor(System.String, Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags, System.IServiceProvider)
    
        
    
        
        Creates a new instance of a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.
    
        
    
        
        :param protectionDescriptorRule: The rule string from which to create the protection descriptor.
        
        :type protectionDescriptorRule: System.String
    
        
        :param flags: Flags controlling the creation of the protection descriptor.
        
        :type flags: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public DpapiNGXmlEncryptor(string protectionDescriptorRule, DpapiNGProtectionDescriptorFlags flags, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        
        Encrypts the specified :any:`System.Xml.Linq.XElement`\.
    
        
    
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: 
            An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo` that contains the encrypted value of
            <em>plaintextElement</em> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
            public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


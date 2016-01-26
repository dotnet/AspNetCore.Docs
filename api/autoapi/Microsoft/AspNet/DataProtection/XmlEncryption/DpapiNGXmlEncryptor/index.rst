

DpapiNGXmlEncryptor Class
=========================



.. contents:: 
   :local:



Summary
-------

A class that can encrypt XML elements using Windows DPAPI:NG.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`








Syntax
------

.. code-block:: csharp

   public sealed class DpapiNGXmlEncryptor : IXmlEncryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/DpapiNGXmlEncryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor.DpapiNGXmlEncryptor(System.String, Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags)
    
        
    
        Creates a new instance of a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.
    
        
        
        
        :param protectionDescriptorRule: The rule string from which to create the protection descriptor.
        
        :type protectionDescriptorRule: System.String
        
        
        :param flags: Flags controlling the creation of the protection descriptor.
        
        :type flags: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
    
        
        .. code-block:: csharp
    
           public DpapiNGXmlEncryptor(string protectionDescriptorRule, DpapiNGProtectionDescriptorFlags flags)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor.DpapiNGXmlEncryptor(System.String, Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags, System.IServiceProvider)
    
        
    
        Creates a new instance of a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.
    
        
        
        
        :param protectionDescriptorRule: The rule string from which to create the protection descriptor.
        
        :type protectionDescriptorRule: System.String
        
        
        :param flags: Flags controlling the creation of the protection descriptor.
        
        :type flags: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public DpapiNGXmlEncryptor(string protectionDescriptorRule, DpapiNGProtectionDescriptorFlags flags, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        Encrypts the specified :any:`System.Xml.Linq.XElement`\.
    
        
        
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo" /> that contains the encrypted value of
            <paramref name="plaintextElement" /> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
           public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


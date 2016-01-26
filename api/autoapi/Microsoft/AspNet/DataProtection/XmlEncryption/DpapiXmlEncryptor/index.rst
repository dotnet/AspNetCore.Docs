

DpapiXmlEncryptor Class
=======================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML by using Windows DPAPI.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor`








Syntax
------

.. code-block:: csharp

   public sealed class DpapiXmlEncryptor : IXmlEncryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/DpapiXmlEncryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor.DpapiXmlEncryptor(System.Boolean)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor` given a protection scope.
    
        
        
        
        :param protectToLocalMachine: 'true' if the data should be decipherable by anybody on the local machine,
            'false' if the data should only be decipherable by the current Windows user account.
        
        :type protectToLocalMachine: System.Boolean
    
        
        .. code-block:: csharp
    
           public DpapiXmlEncryptor(bool protectToLocalMachine)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor.DpapiXmlEncryptor(System.Boolean, System.IServiceProvider)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor` given a protection scope and an :any:`System.IServiceProvider`\.
    
        
        
        
        :param protectToLocalMachine: 'true' if the data should be decipherable by anybody on the local machine,
            'false' if the data should only be decipherable by the current Windows user account.
        
        :type protectToLocalMachine: System.Boolean
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public DpapiXmlEncryptor(bool protectToLocalMachine, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        Encrypts the specified :any:`System.Xml.Linq.XElement`\.
    
        
        
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo" /> that contains the encrypted value of
            <paramref name="plaintextElement" /> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
           public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    


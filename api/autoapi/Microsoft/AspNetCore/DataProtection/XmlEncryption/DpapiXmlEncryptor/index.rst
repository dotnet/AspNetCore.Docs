

DpapiXmlEncryptor Class
=======================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML by using Windows DPAPI.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor`








Syntax
------

.. code-block:: csharp

    public sealed class DpapiXmlEncryptor : IXmlEncryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor.DpapiXmlEncryptor(System.Boolean)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor` given a protection scope.
    
        
    
        
        :param protectToLocalMachine: 'true' if the data should be decipherable by anybody on the local machine,
            'false' if the data should only be decipherable by the current Windows user account.
        
        :type protectToLocalMachine: System.Boolean
    
        
        .. code-block:: csharp
    
            public DpapiXmlEncryptor(bool protectToLocalMachine)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor.DpapiXmlEncryptor(System.Boolean, System.IServiceProvider)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor` given a protection scope and an :any:`System.IServiceProvider`\.
    
        
    
        
        :param protectToLocalMachine: 'true' if the data should be decipherable by anybody on the local machine,
            'false' if the data should only be decipherable by the current Windows user account.
        
        :type protectToLocalMachine: System.Boolean
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public DpapiXmlEncryptor(bool protectToLocalMachine, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        
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
    


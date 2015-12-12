

DpapiXmlDecryptor Class
=======================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor`








Syntax
------

.. code-block:: csharp

   public sealed class DpapiXmlDecryptor : IXmlDecryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/DpapiXmlDecryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor.DpapiXmlDecryptor()
    
        
    
        Creates a new instance of a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor`\.
    
        
    
        
        .. code-block:: csharp
    
           public DpapiXmlDecryptor()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor.DpapiXmlDecryptor(System.IServiceProvider)
    
        
    
        Creates a new instance of a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor`\.
    
        
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public DpapiXmlDecryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
        
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           public XElement Decrypt(XElement encryptedElement)
    


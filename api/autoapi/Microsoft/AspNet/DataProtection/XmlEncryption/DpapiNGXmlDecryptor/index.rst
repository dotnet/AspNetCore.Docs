

DpapiNGXmlDecryptor Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`








Syntax
------

.. code-block:: csharp

   public sealed class DpapiNGXmlDecryptor : IXmlDecryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/XmlEncryption/DpapiNGXmlDecryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor.DpapiNGXmlDecryptor()
    
        
    
        Creates a new instance of a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`\.
    
        
    
        
        .. code-block:: csharp
    
           public DpapiNGXmlDecryptor()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor.DpapiNGXmlDecryptor(System.IServiceProvider)
    
        
    
        Creates a new instance of a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`\.
    
        
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public DpapiNGXmlDecryptor(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor.Decrypt(System.Xml.Linq.XElement)
    
        
        
        
        :type encryptedElement: System.Xml.Linq.XElement
        :rtype: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           public XElement Decrypt(XElement encryptedElement)
    


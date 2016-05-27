

XmlDocumentDecryptor Class
==========================





Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.Xml`
Assemblies
    * Microsoft.Extensions.Configuration.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor`








Syntax
------

.. code-block:: csharp

    public class XmlDocumentDecryptor








.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor.XmlDocumentDecryptor()
    
        
    
        
        .. code-block:: csharp
    
            protected XmlDocumentDecryptor()
    

Fields
------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor.Instance
    
        
    
        
        Accesses the singleton decryptor instance.
    
        
        :rtype: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor
    
        
        .. code-block:: csharp
    
            public static readonly XmlDocumentDecryptor Instance
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor.CreateDecryptingXmlReader(System.IO.Stream, System.Xml.XmlReaderSettings)
    
        
    
        
        Returns an XmlReader that decrypts data transparently.
    
        
    
        
        :type input: System.IO.Stream
    
        
        :type settings: System.Xml.XmlReaderSettings
        :rtype: System.Xml.XmlReader
    
        
        .. code-block:: csharp
    
            public XmlReader CreateDecryptingXmlReader(Stream input, XmlReaderSettings settings)
    
    .. dn:method:: Microsoft.Extensions.Configuration.Xml.XmlDocumentDecryptor.DecryptDocumentAndCreateXmlReader(System.Xml.XmlDocument)
    
        
    
        
        :type document: System.Xml.XmlDocument
        :rtype: System.Xml.XmlReader
    
        
        .. code-block:: csharp
    
            protected virtual XmlReader DecryptDocumentAndCreateXmlReader(XmlDocument document)
    


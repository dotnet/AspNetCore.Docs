

FormattingUtilities Class
=========================






Contains methods which are used by Xml input formatters.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities`








Syntax
------

.. code-block:: csharp

    public class FormattingUtilities








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities.GetDefaultXmlReaderQuotas()
    
        
    
        
        Gets the default Reader Quotas for XmlReader.
    
        
        :rtype: System.Xml.XmlDictionaryReaderQuotas
        :return: XmlReaderQuotas with default values
    
        
        .. code-block:: csharp
    
            public static XmlDictionaryReaderQuotas GetDefaultXmlReaderQuotas()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities.GetDefaultXmlWriterSettings()
    
        
    
        
        Gets the default XmlWriterSettings.
    
        
        :rtype: System.Xml.XmlWriterSettings
        :return: Default :any:`System.Xml.XmlWriterSettings`
    
        
        .. code-block:: csharp
    
            public static XmlWriterSettings GetDefaultXmlWriterSettings()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities.DefaultMaxDepth
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int DefaultMaxDepth
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.FormattingUtilities.XsdDataContractExporter
    
        
        :rtype: System.Runtime.Serialization.XsdDataContractExporter
    
        
        .. code-block:: csharp
    
            public static readonly XsdDataContractExporter XsdDataContractExporter
    




FormattingUtilities Class
=========================



.. contents:: 
   :local:



Summary
-------

Contains methods which are used by Xml input formatters.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities`








Syntax
------

.. code-block:: csharp

   public class FormattingUtilities





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/Internal/FormattingUtilities.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities.GetDefaultXmlReaderQuotas()
    
        
    
        Gets the default Reader Quotas for XmlReader.
    
        
        :rtype: System.Xml.XmlDictionaryReaderQuotas
        :return: XmlReaderQuotas with default values
    
        
        .. code-block:: csharp
    
           public static XmlDictionaryReaderQuotas GetDefaultXmlReaderQuotas()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities.GetDefaultXmlWriterSettings()
    
        
    
        Gets the default XmlWriterSettings.
    
        
        :rtype: System.Xml.XmlWriterSettings
        :return: Default <see cref="T:System.Xml.XmlWriterSettings" />
    
        
        .. code-block:: csharp
    
           public static XmlWriterSettings GetDefaultXmlWriterSettings()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.FormattingUtilities.DefaultMaxDepth
    
        
    
        
        .. code-block:: csharp
    
           public static readonly int DefaultMaxDepth
    


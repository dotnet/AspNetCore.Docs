

XmlExtensions Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions`








Syntax
------

.. code-block:: csharp

   public class XmlExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/XmlExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions.MarkAsRequiresEncryption(System.Xml.Linq.XElement)
    
        
    
        Marks the provided :any:`System.Xml.Linq.XElement` as requiring encryption before being persisted
        to storage. Use when implementing :dn:meth:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor.ExportToXml`\.
    
        
        
        
        :type element: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           public static void MarkAsRequiresEncryption(XElement element)
    


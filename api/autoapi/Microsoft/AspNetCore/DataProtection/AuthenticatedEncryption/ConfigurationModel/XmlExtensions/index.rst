

XmlExtensions Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions`








Syntax
------

.. code-block:: csharp

    public class XmlExtensions








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlExtensions.MarkAsRequiresEncryption(System.Xml.Linq.XElement)
    
        
    
        
        Marks the provided :any:`System.Xml.Linq.XElement` as requiring encryption before being persisted
        to storage. Use when implementing :dn:meth:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor.ExportToXml`\.
    
        
    
        
        :type element: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
            public static void MarkAsRequiresEncryption(XElement element)
    


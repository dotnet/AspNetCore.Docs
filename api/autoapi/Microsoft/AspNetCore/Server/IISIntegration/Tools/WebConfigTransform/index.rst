

WebConfigTransform Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.IISIntegration.Tools`
Assemblies
    * Microsoft.AspNetCore.Server.IISIntegration.Tools

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.IISIntegration.Tools.WebConfigTransform`








Syntax
------

.. code-block:: csharp

    public class WebConfigTransform








.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.Tools.WebConfigTransform
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.Tools.WebConfigTransform

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.Tools.WebConfigTransform
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.IISIntegration.Tools.WebConfigTransform.Transform(System.Xml.Linq.XDocument, System.String, System.Boolean, System.Boolean)
    
        
    
        
        :type webConfig: System.Xml.Linq.XDocument
    
        
        :type appName: System.String
    
        
        :type configureForAzure: System.Boolean
    
        
        :type isPortable: System.Boolean
        :rtype: System.Xml.Linq.XDocument
    
        
        .. code-block:: csharp
    
            public static XDocument Transform(XDocument webConfig, string appName, bool configureForAzure, bool isPortable)
    


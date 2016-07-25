

WebHostOptions Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.WebHostOptions`








Syntax
------

.. code-block:: csharp

    public class WebHostOptions








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.WebHostOptions()
    
        
    
        
        .. code-block:: csharp
    
            public WebHostOptions()
    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.WebHostOptions(Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
            public WebHostOptions(IConfiguration configuration)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.ApplicationName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplicationName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.CaptureStartupErrors
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CaptureStartupErrors { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.ContentRootPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentRootPath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.DetailedErrors
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool DetailedErrors { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.Environment
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Environment { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.StartupAssembly
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string StartupAssembly { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions.WebRoot
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WebRoot { get; set; }
    


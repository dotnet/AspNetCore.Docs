

HostingEnvironment Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment`








Syntax
------

.. code-block:: csharp

    public class HostingEnvironment : IHostingEnvironment








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment.ApplicationName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplicationName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment.ContentRootFileProvider
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider ContentRootFileProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment.ContentRootPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentRootPath
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment.EnvironmentName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EnvironmentName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment.WebRootFileProvider
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider WebRootFileProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment.WebRootPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WebRootPath
            {
                get;
                set;
            }
    


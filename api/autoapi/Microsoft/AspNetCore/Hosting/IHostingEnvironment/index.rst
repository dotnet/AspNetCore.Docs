

IHostingEnvironment Interface
=============================






Provides information about the web hosting environment an application is running in.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHostingEnvironment








.. dn:interface:: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.IHostingEnvironment

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IHostingEnvironment.ApplicationName
    
        
    
        
        Gets or sets the name of the application. This property is automatically set by the host to the assembly containing
        the application entry point.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ApplicationName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootFileProvider
    
        
    
        
        Gets or sets an :any:`Microsoft.Extensions.FileProviders.IFileProvider` pointing at :dn:prop:`Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootPath`\.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            IFileProvider ContentRootFileProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootPath
    
        
    
        
        Gets or sets the absolute path to the directory that contains the application content files.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ContentRootPath
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IHostingEnvironment.EnvironmentName
    
        
    
        
        Gets or sets the name of the environment. This property is automatically set by the host to the value
        of the "ASPNETCORE_ENVIRONMENT" environment variable.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string EnvironmentName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IHostingEnvironment.WebRootFileProvider
    
        
    
        
        Gets or sets an :any:`Microsoft.Extensions.FileProviders.IFileProvider` pointing at :dn:prop:`Microsoft.AspNetCore.Hosting.IHostingEnvironment.WebRootPath`\.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            IFileProvider WebRootFileProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IHostingEnvironment.WebRootPath
    
        
    
        
        Gets or sets the absolute path to the directory that contains the web-servable application content files.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string WebRootPath
            {
                get;
                set;
            }
    


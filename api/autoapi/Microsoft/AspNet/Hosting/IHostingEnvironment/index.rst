

IHostingEnvironment Interface
=============================



.. contents:: 
   :local:



Summary
-------

Provides information about the web hosting environment an application is running in.











Syntax
------

.. code-block:: csharp

   public interface IHostingEnvironment





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting.Abstractions/IHostingEnvironment.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.IHostingEnvironment

Properties
----------

.. dn:interface:: Microsoft.AspNet.Hosting.IHostingEnvironment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.IHostingEnvironment.EnvironmentName
    
        
    
        Gets or sets the name of the environment. This property is automatically set by the host to the value
        of the "Hosting:Environment" (on Windows) or "Hosting__Environment" (on Linux &amp; OS X) environment variable.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string EnvironmentName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.IHostingEnvironment.WebRootFileProvider
    
        
    
        Gets or sets an :any:`Microsoft.AspNet.FileProviders.IFileProvider` pointing at :dn:prop:`Microsoft.AspNet.Hosting.IHostingEnvironment.WebRootPath`\.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           IFileProvider WebRootFileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.IHostingEnvironment.WebRootPath
    
        
    
        Gets or sets the absolute path to the directory that contains the web-servable application content files.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string WebRootPath { get; set; }
    


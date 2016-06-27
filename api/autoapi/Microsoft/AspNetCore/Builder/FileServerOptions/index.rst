

FileServerOptions Class
=======================






Options for all of the static file middleware components


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase`
* :dn:cls:`Microsoft.AspNetCore.Builder.FileServerOptions`








Syntax
------

.. code-block:: csharp

    public class FileServerOptions : SharedOptionsBase








.. dn:class:: Microsoft.AspNetCore.Builder.FileServerOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.FileServerOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.FileServerOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.FileServerOptions.FileServerOptions()
    
        
    
        
        Creates a combined options class for all of the static file middleware components.
    
        
    
        
        .. code-block:: csharp
    
            public FileServerOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.FileServerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.FileServerOptions.DefaultFilesOptions
    
        
    
        
        Options for configuring the DefaultFilesMiddleware.
    
        
        :rtype: Microsoft.AspNetCore.Builder.DefaultFilesOptions
    
        
        .. code-block:: csharp
    
            public DefaultFilesOptions DefaultFilesOptions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FileServerOptions.DirectoryBrowserOptions
    
        
    
        
        Options for configuring the DirectoryBrowserMiddleware.
    
        
        :rtype: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions
    
        
        .. code-block:: csharp
    
            public DirectoryBrowserOptions DirectoryBrowserOptions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FileServerOptions.EnableDefaultFiles
    
        
    
        
        Default files are enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool EnableDefaultFiles { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FileServerOptions.EnableDirectoryBrowsing
    
        
    
        
        Directory browsing is disabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool EnableDirectoryBrowsing { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FileServerOptions.StaticFileOptions
    
        
    
        
        Options for configuring the StaticFileMiddleware.
    
        
        :rtype: Microsoft.AspNetCore.Builder.StaticFileOptions
    
        
        .. code-block:: csharp
    
            public StaticFileOptions StaticFileOptions { get; }
    


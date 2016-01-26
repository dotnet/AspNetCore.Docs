

FileServerOptions Class
=======================



.. contents:: 
   :local:



Summary
-------

Options for all of the static file middleware components





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase{Microsoft.AspNet.StaticFiles.FileServerOptions}`
* :dn:cls:`Microsoft.AspNet.StaticFiles.FileServerOptions`








Syntax
------

.. code-block:: csharp

   public class FileServerOptions : SharedOptionsBase<FileServerOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/FileServerOptions.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.FileServerOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.FileServerOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.FileServerOptions.FileServerOptions()
    
        
    
        Creates a combined options class for all of the static file middleware components.
    
        
    
        
        .. code-block:: csharp
    
           public FileServerOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.FileServerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.FileServerOptions.DefaultFilesOptions
    
        
    
        Options for configuring the DefaultFilesMiddleware.
    
        
        :rtype: Microsoft.AspNet.StaticFiles.DefaultFilesOptions
    
        
        .. code-block:: csharp
    
           public DefaultFilesOptions DefaultFilesOptions { get; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.FileServerOptions.DirectoryBrowserOptions
    
        
    
        Options for configuring the DirectoryBrowserMiddleware.
    
        
        :rtype: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions
    
        
        .. code-block:: csharp
    
           public DirectoryBrowserOptions DirectoryBrowserOptions { get; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.FileServerOptions.EnableDefaultFiles
    
        
    
        Default files are enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool EnableDefaultFiles { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.FileServerOptions.EnableDirectoryBrowsing
    
        
    
        Directory browsing is disabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool EnableDirectoryBrowsing { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.FileServerOptions.StaticFileOptions
    
        
    
        Options for configuring the StaticFileMiddleware.
    
        
        :rtype: Microsoft.AspNet.StaticFiles.StaticFileOptions
    
        
        .. code-block:: csharp
    
           public StaticFileOptions StaticFileOptions { get; }
    




IFileInfo Interface
===================



.. contents:: 
   :local:



Summary
-------

Represents a file in the given file provider.











Syntax
------

.. code-block:: csharp

   public interface IFileInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.AspNet.FileProviders.Abstractions/IFileInfo.cs>`_





.. dn:interface:: Microsoft.AspNet.FileProviders.IFileInfo

Methods
-------

.. dn:interface:: Microsoft.AspNet.FileProviders.IFileInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.FileProviders.IFileInfo.CreateReadStream()
    
        
    
        Return file contents as readonly stream. Caller should dispose stream when complete.
    
        
        :rtype: System.IO.Stream
        :return: The file stream
    
        
        .. code-block:: csharp
    
           Stream CreateReadStream()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.FileProviders.IFileInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.FileProviders.IFileInfo.Exists
    
        
    
        True if resource exists in the underlying storage system.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool Exists { get; }
    
    .. dn:property:: Microsoft.AspNet.FileProviders.IFileInfo.IsDirectory
    
        
    
        True for the case TryGetDirectoryContents has enumerated a sub-directory
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsDirectory { get; }
    
    .. dn:property:: Microsoft.AspNet.FileProviders.IFileInfo.LastModified
    
        
    
        When the file was last modified
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           DateTimeOffset LastModified { get; }
    
    .. dn:property:: Microsoft.AspNet.FileProviders.IFileInfo.Length
    
        
    
        The length of the file in bytes, or -1 for a directory or non-existing files.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           long Length { get; }
    
    .. dn:property:: Microsoft.AspNet.FileProviders.IFileInfo.Name
    
        
    
        The name of the file or directory, not including any path.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.FileProviders.IFileInfo.PhysicalPath
    
        
    
        The path to the file, including the file name. Return null if the file is not directly accessible.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string PhysicalPath { get; }
    


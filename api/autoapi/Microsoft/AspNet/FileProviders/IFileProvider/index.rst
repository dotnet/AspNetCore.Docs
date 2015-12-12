

IFileProvider Interface
=======================



.. contents:: 
   :local:



Summary
-------

A read-only file provider abstraction.











Syntax
------

.. code-block:: csharp

   public interface IFileProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.AspNet.FileProviders.Abstractions/IFileProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.FileProviders.IFileProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.FileProviders.IFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.FileProviders.IFileProvider.GetDirectoryContents(System.String)
    
        
    
        Enumerate a directory at the given path, if any.
    
        
        
        
        :param subpath: Relative path that identifies the directory.
        
        :type subpath: System.String
        :rtype: Microsoft.AspNet.FileProviders.IDirectoryContents
        :return: Returns the contents of the directory.
    
        
        .. code-block:: csharp
    
           IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.AspNet.FileProviders.IFileProvider.GetFileInfo(System.String)
    
        
    
        Locate a file at the given path.
    
        
        
        
        :param subpath: Relative path that identifies the file.
        
        :type subpath: System.String
        :rtype: Microsoft.AspNet.FileProviders.IFileInfo
        :return: The file information. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
           IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.AspNet.FileProviders.IFileProvider.Watch(System.String)
    
        
    
        Creates a :any:`Microsoft.Extensions.Primitives.IChangeToken` for the specified ``filter``.
    
        
        
        
        :param filter: Filter string used to determine what files or folders to monitor. Example: \*\*/\*.cs, \*.\*, subFolder/\*\*/\*.cshtml.
        
        :type filter: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
        :return: An <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" /> that is notified when a file matching <paramref name="filter" /> is added, modified or deleted.
    
        
        .. code-block:: csharp
    
           IChangeToken Watch(string filter)
    




IFileProvider Interface
=======================






A read-only file provider abstraction.


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFileProvider








.. dn:interface:: Microsoft.Extensions.FileProviders.IFileProvider
    :hidden:

.. dn:interface:: Microsoft.Extensions.FileProviders.IFileProvider

Methods
-------

.. dn:interface:: Microsoft.Extensions.FileProviders.IFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.IFileProvider.GetDirectoryContents(System.String)
    
        
    
        
        Enumerate a directory at the given path, if any.
    
        
    
        
        :param subpath: Relative path that identifies the directory.
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IDirectoryContents
        :return: Returns the contents of the directory.
    
        
        .. code-block:: csharp
    
            IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.IFileProvider.GetFileInfo(System.String)
    
        
    
        
        Locate a file at the given path.
    
        
    
        
        :param subpath: Relative path that identifies the file.
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IFileInfo
        :return: The file information. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
            IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.IFileProvider.Watch(System.String)
    
        
    
        
        Creates a :any:`Microsoft.Extensions.Primitives.IChangeToken` for the specified <em>filter</em>.
    
        
    
        
        :param filter: Filter string used to determine what files or folders to monitor. Example: ``**/*.cs``, ``*.*``, ``subFolder/**/*.cshtml``.
        
        :type filter: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
        :return: An :any:`Microsoft.Extensions.Primitives.IChangeToken` that is notified when a file matching <em>filter</em> is added, modified or deleted.
    
        
        .. code-block:: csharp
    
            IChangeToken Watch(string filter)
    


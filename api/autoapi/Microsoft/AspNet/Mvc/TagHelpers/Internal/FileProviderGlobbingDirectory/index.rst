

FileProviderGlobbingDirectory Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory`








Syntax
------

.. code-block:: csharp

   public class FileProviderGlobbingDirectory : DirectoryInfoBase





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/FileProviderGlobbingDirectory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.FileProviderGlobbingDirectory(Microsoft.AspNet.FileProviders.IFileProvider, Microsoft.AspNet.FileProviders.IFileInfo, Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory)
    
        
        
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
        
        
        :type fileInfo: Microsoft.AspNet.FileProviders.IFileInfo
        
        
        :type parent: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    
        
        .. code-block:: csharp
    
           public FileProviderGlobbingDirectory(IFileProvider fileProvider, IFileInfo fileInfo, FileProviderGlobbingDirectory parent)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.EnumerateFileSystemInfos()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos()
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.GetDirectory(System.String)
    
        
        
        
        :type path: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public override DirectoryInfoBase GetDirectory(string path)
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.GetFile(System.String)
    
        
        
        
        :type path: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
    
        
        .. code-block:: csharp
    
           public override FileInfoBase GetFile(string path)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string FullName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public override DirectoryInfoBase ParentDirectory { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.RelativePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RelativePath { get; }
    


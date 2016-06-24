

FileProviderGlobbingDirectory Class
===================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory`








Syntax
------

.. code-block:: csharp

    public class FileProviderGlobbingDirectory : DirectoryInfoBase








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.FileProviderGlobbingDirectory(Microsoft.Extensions.FileProviders.IFileProvider, Microsoft.Extensions.FileProviders.IFileInfo, Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory)
    
        
    
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        :type fileInfo: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        :type parent: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    
        
        .. code-block:: csharp
    
            public FileProviderGlobbingDirectory(IFileProvider fileProvider, IFileInfo fileInfo, FileProviderGlobbingDirectory parent)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.EnumerateFileSystemInfos()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase<Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase>}
    
        
        .. code-block:: csharp
    
            public override IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.GetDirectory(System.String)
    
        
    
        
        :type path: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public override DirectoryInfoBase GetDirectory(string path)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.GetFile(System.String)
    
        
    
        
        :type path: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
    
        
        .. code-block:: csharp
    
            public override FileInfoBase GetFile(string path)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string FullName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public override DirectoryInfoBase ParentDirectory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingDirectory.RelativePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RelativePath { get; }
    


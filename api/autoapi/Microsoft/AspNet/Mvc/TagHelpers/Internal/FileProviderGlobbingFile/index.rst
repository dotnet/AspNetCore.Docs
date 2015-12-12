

FileProviderGlobbingFile Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile`








Syntax
------

.. code-block:: csharp

   public class FileProviderGlobbingFile : FileInfoBase





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/FileProviderGlobbingFile.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.FileProviderGlobbingFile(Microsoft.AspNet.FileProviders.IFileInfo, Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type fileInfo: Microsoft.AspNet.FileProviders.IFileInfo
        
        
        :type parent: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public FileProviderGlobbingFile(IFileInfo fileInfo, DirectoryInfoBase parent)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string FullName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public override DirectoryInfoBase ParentDirectory { get; }
    


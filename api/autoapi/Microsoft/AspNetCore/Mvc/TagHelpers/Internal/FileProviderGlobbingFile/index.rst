

FileProviderGlobbingFile Class
==============================





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
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile`








Syntax
------

.. code-block:: csharp

    public class FileProviderGlobbingFile : FileInfoBase








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.FileProviderGlobbingFile(Microsoft.Extensions.FileProviders.IFileInfo, Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
    
        
        :type fileInfo: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        :type parent: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public FileProviderGlobbingFile(IFileInfo fileInfo, DirectoryInfoBase parent)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string FullName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileProviderGlobbingFile.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public override DirectoryInfoBase ParentDirectory { get; }
    


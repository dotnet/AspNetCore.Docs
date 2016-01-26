

DirectoryInfoWrapper Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper`








Syntax
------

.. code-block:: csharp

   public class DirectoryInfoWrapper : DirectoryInfoBase





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Abstractions/DirectoryInfoWrapper.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.DirectoryInfoWrapper(System.IO.DirectoryInfo, System.Boolean)
    
        
        
        
        :type directoryInfo: System.IO.DirectoryInfo
        
        
        :type isParentPath: System.Boolean
    
        
        .. code-block:: csharp
    
           public DirectoryInfoWrapper(DirectoryInfo directoryInfo, bool isParentPath = false)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.EnumerateFileSystemInfos()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.GetDirectory(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public override DirectoryInfoBase GetDirectory(string name)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.GetFile(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
    
        
        .. code-block:: csharp
    
           public override FileInfoBase GetFile(string name)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string FullName { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public override DirectoryInfoBase ParentDirectory { get; }
    


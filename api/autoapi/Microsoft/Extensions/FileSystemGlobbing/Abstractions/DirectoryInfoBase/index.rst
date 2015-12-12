

DirectoryInfoBase Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase`








Syntax
------

.. code-block:: csharp

   public abstract class DirectoryInfoBase : FileSystemInfoBase





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/Abstractions/DirectoryInfoBase.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase.EnumerateFileSystemInfos()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase}
    
        
        .. code-block:: csharp
    
           public abstract IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase.GetDirectory(System.String)
    
        
        
        
        :type path: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public abstract DirectoryInfoBase GetDirectory(string path)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase.GetFile(System.String)
    
        
        
        
        :type path: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
    
        
        .. code-block:: csharp
    
           public abstract FileInfoBase GetFile(string path)
    


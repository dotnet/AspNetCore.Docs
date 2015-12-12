

FileSystemInfoBase Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`








Syntax
------

.. code-block:: csharp

   public abstract class FileSystemInfoBase





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Abstractions/FileSystemInfoBase.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string FullName { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public abstract DirectoryInfoBase ParentDirectory { get; }
    


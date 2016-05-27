

FileInfoWrapper Class
=====================





Namespace
    :dn:ns:`Microsoft.Extensions.FileSystemGlobbing.Abstractions`
Assemblies
    * Microsoft.Extensions.FileSystemGlobbing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper`








Syntax
------

.. code-block:: csharp

    public class FileInfoWrapper : FileInfoBase








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string FullName
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper.ParentDirectory
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public override DirectoryInfoBase ParentDirectory
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoWrapper.FileInfoWrapper(System.IO.FileInfo)
    
        
    
        
        :type fileInfo: System.IO.FileInfo
    
        
        .. code-block:: csharp
    
            public FileInfoWrapper(FileInfo fileInfo)
    




PhysicalDirectoryInfo Class
===========================





Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders.Physical`
Assemblies
    * Microsoft.Extensions.FileProviders.Physical

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo`








Syntax
------

.. code-block:: csharp

    public class PhysicalDirectoryInfo : IFileInfo








.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.PhysicalDirectoryInfo(System.IO.DirectoryInfo)
    
        
    
        
        :type info: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
            public PhysicalDirectoryInfo(DirectoryInfo info)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.CreateReadStream()
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream CreateReadStream()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.Exists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Exists { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.IsDirectory
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsDirectory { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.LastModified
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset LastModified { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Length { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalDirectoryInfo.PhysicalPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PhysicalPath { get; }
    


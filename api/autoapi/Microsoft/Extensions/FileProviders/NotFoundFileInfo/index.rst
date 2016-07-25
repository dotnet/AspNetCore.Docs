

NotFoundFileInfo Class
======================






Represents a non-existing file.


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.NotFoundFileInfo`








Syntax
------

.. code-block:: csharp

    public class NotFoundFileInfo : IFileInfo








.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundFileInfo
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundFileInfo

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundFileInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.NotFoundFileInfo(System.String)
    
        
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public NotFoundFileInfo(string name)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundFileInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.CreateReadStream()
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream CreateReadStream()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundFileInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.Exists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Exists { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.IsDirectory
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsDirectory { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.LastModified
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset LastModified { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Length { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundFileInfo.PhysicalPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PhysicalPath { get; }
    


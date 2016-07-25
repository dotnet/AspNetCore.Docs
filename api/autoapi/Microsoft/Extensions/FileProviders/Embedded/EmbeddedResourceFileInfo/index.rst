

EmbeddedResourceFileInfo Class
==============================





Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders.Embedded`
Assemblies
    * Microsoft.Extensions.FileProviders.Embedded

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo`








Syntax
------

.. code-block:: csharp

    public class EmbeddedResourceFileInfo : IFileInfo








.. dn:class:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.EmbeddedResourceFileInfo(System.Reflection.Assembly, System.String, System.String, System.DateTimeOffset)
    
        
    
        
        :type assembly: System.Reflection.Assembly
    
        
        :type resourcePath: System.String
    
        
        :type name: System.String
    
        
        :type lastModified: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public EmbeddedResourceFileInfo(Assembly assembly, string resourcePath, string name, DateTimeOffset lastModified)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.CreateReadStream()
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream CreateReadStream()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.Exists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Exists { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.IsDirectory
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsDirectory { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.LastModified
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset LastModified { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Length { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Embedded.EmbeddedResourceFileInfo.PhysicalPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PhysicalPath { get; }
    


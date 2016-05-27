

PhysicalFileInfo Class
======================





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
* :dn:cls:`Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo`








Syntax
------

.. code-block:: csharp

    public class PhysicalFileInfo : IFileInfo








.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.Exists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Exists
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.IsDirectory
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsDirectory
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.LastModified
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset LastModified
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.PhysicalPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PhysicalPath
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.PhysicalFileInfo(System.IO.FileInfo)
    
        
    
        
        :type info: System.IO.FileInfo
    
        
        .. code-block:: csharp
    
            public PhysicalFileInfo(FileInfo info)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo.CreateReadStream()
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream CreateReadStream()
    


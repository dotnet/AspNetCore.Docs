

PhysicalFileProvider Class
==========================






Looks up files using the on-disk file system


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Physical

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.PhysicalFileProvider`








Syntax
------

.. code-block:: csharp

    public class PhysicalFileProvider : IFileProvider, IDisposable








.. dn:class:: Microsoft.Extensions.FileProviders.PhysicalFileProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.PhysicalFileProvider

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.PhysicalFileProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.PhysicalFileProvider.Root
    
        
    
        
        The root directory for this instance.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Root
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.PhysicalFileProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.PhysicalFileProvider.PhysicalFileProvider(System.String)
    
        
    
        
        Creates a new instance of a PhysicalFileProvider at the given root directory.
    
        
    
        
        :param root: The root directory. This should be an absolute path.
        
        :type root: System.String
    
        
        .. code-block:: csharp
    
            public PhysicalFileProvider(string root)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.PhysicalFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.PhysicalFileProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.Extensions.FileProviders.PhysicalFileProvider.GetDirectoryContents(System.String)
    
        
    
        
        Enumerate a directory at the given path, if any.
    
        
    
        
        :param subpath: A path under the root directory
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IDirectoryContents
        :return: Contents of the directory. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
            public IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.PhysicalFileProvider.GetFileInfo(System.String)
    
        
    
        
        Locate a file at the given path by directly mapping path segments to physical directories.
    
        
    
        
        :param subpath: A path under the root directory
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IFileInfo
        :return: The file information. Caller must check Exists property. 
    
        
        .. code-block:: csharp
    
            public IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.PhysicalFileProvider.Watch(System.String)
    
        
    
        
        :type filter: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken Watch(string filter)
    


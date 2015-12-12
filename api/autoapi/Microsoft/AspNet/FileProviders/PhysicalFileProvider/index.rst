

PhysicalFileProvider Class
==========================



.. contents:: 
   :local:



Summary
-------

Looks up files using the on-disk file system





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.FileProviders.PhysicalFileProvider`








Syntax
------

.. code-block:: csharp

   public class PhysicalFileProvider : IFileProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.AspNet.FileProviders.Physical/PhysicalFileProvider.cs>`_





.. dn:class:: Microsoft.AspNet.FileProviders.PhysicalFileProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.FileProviders.PhysicalFileProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.FileProviders.PhysicalFileProvider.PhysicalFileProvider(System.String)
    
        
    
        Creates a new instance of a PhysicalFileProvider at the given root directory.
    
        
        
        
        :param root: The root directory. This should be an absolute path.
        
        :type root: System.String
    
        
        .. code-block:: csharp
    
           public PhysicalFileProvider(string root)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.FileProviders.PhysicalFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.FileProviders.PhysicalFileProvider.GetDirectoryContents(System.String)
    
        
    
        Enumerate a directory at the given path, if any.
    
        
        
        
        :param subpath: A path under the root directory
        
        :type subpath: System.String
        :rtype: Microsoft.AspNet.FileProviders.IDirectoryContents
        :return: Contents of the directory. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
           public IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.AspNet.FileProviders.PhysicalFileProvider.GetFileInfo(System.String)
    
        
    
        Locate a file at the given path by directly mapping path segments to physical directories.
    
        
        
        
        :param subpath: A path under the root directory
        
        :type subpath: System.String
        :rtype: Microsoft.AspNet.FileProviders.IFileInfo
        :return: The file information. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
           public IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.AspNet.FileProviders.PhysicalFileProvider.Watch(System.String)
    
        
        
        
        :type filter: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
           public IChangeToken Watch(string filter)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.FileProviders.PhysicalFileProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.FileProviders.PhysicalFileProvider.Root
    
        
    
        The root directory for this instance.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Root { get; }
    


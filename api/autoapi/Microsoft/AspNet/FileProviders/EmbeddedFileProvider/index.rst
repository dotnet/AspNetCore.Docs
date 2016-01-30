

EmbeddedFileProvider Class
==========================



.. contents:: 
   :local:



Summary
-------

Looks up files using embedded resources in the specified assembly.
This file provider is case sensitive.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.FileProviders.EmbeddedFileProvider`








Syntax
------

.. code-block:: csharp

   public class EmbeddedFileProvider : IFileProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.AspNet.FileProviders.Embedded/EmbeddedFileProvider.cs>`_





.. dn:class:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider.EmbeddedFileProvider(System.Reflection.Assembly)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.FileProviders.EmbeddedFileProvider` class using the specified
        assembly and empty base namespace.
    
        
        
        
        :type assembly: System.Reflection.Assembly
    
        
        .. code-block:: csharp
    
           public EmbeddedFileProvider(Assembly assembly)
    
    .. dn:constructor:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider.EmbeddedFileProvider(System.Reflection.Assembly, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.FileProviders.EmbeddedFileProvider` class using the specified
        assembly and base namespace.
    
        
        
        
        :param assembly: The assembly that contains the embedded resources.
        
        :type assembly: System.Reflection.Assembly
        
        
        :param baseNamespace: The base namespace that contains the embedded resources.
        
        :type baseNamespace: System.String
    
        
        .. code-block:: csharp
    
           public EmbeddedFileProvider(Assembly assembly, string baseNamespace)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider.GetDirectoryContents(System.String)
    
        
    
        Enumerate a directory at the given path, if any.
        This file provider uses a flat directory structure. Everything under the base namespace is considered to be one directory.
    
        
        
        
        :param subpath: The path that identifies the directory
        
        :type subpath: System.String
        :rtype: Microsoft.AspNet.FileProviders.IDirectoryContents
        :return: Contents of the directory. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
           public IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider.GetFileInfo(System.String)
    
        
    
        Locates a file at the given path.
    
        
        
        
        :param subpath: The path that identifies the file.
        
        :type subpath: System.String
        :rtype: Microsoft.AspNet.FileProviders.IFileInfo
        :return: The file information. Caller must check Exists property.
    
        
        .. code-block:: csharp
    
           public IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.AspNet.FileProviders.EmbeddedFileProvider.Watch(System.String)
    
        
        
        
        :type pattern: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
           public IChangeToken Watch(string pattern)
    


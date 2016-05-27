

NullFileProvider Class
======================






An empty file provider with no contents.


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
* :dn:cls:`Microsoft.Extensions.FileProviders.NullFileProvider`








Syntax
------

.. code-block:: csharp

    public class NullFileProvider : IFileProvider








.. dn:class:: Microsoft.Extensions.FileProviders.NullFileProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.NullFileProvider

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.NullFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.NullFileProvider.GetDirectoryContents(System.String)
    
        
    
        
        Enumerate a non-existent directory.
    
        
    
        
        :param subpath: A path under the root directory. This parameter is ignored.
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IDirectoryContents
        :return: A :any:`Microsoft.Extensions.FileProviders.IDirectoryContents` that does not exist and does not contain any contents.
    
        
        .. code-block:: csharp
    
            public IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.NullFileProvider.GetFileInfo(System.String)
    
        
    
        
        Locate a non-existent file.
    
        
    
        
        :param subpath: A path under the root directory.
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IFileInfo
        :return: A :any:`Microsoft.Extensions.FileProviders.IFileInfo` representing a non-existent file at the given path.
    
        
        .. code-block:: csharp
    
            public IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.NullFileProvider.Watch(System.String)
    
        
    
        
        Returns a :any:`Microsoft.Extensions.Primitives.IChangeToken` that monitors nothing.
    
        
    
        
        :param filter: Filter string used to determine what files or folders to monitor. This parameter is ignored.
        
        :type filter: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
        :return: A :any:`Microsoft.Extensions.Primitives.IChangeToken` that does not register callbacks.
    
        
        .. code-block:: csharp
    
            public IChangeToken Watch(string filter)
    

